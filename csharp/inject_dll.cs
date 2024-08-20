using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

class ManualMapper
{
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

    const int PROCESS_ALL_ACCESS = 0x1F0FFF;
    const uint MEM_COMMIT = 0x00001000;
    const uint MEM_RESERVE = 0x00002000;
    const uint PAGE_EXECUTE_READWRITE = 0x40;

    public static void MapDllToMemory(int processId, string dllPath)
    {
        // 讀取DLL文件
        byte[] dllBytes = File.ReadAllBytes(dllPath);

        // 打開目標進程
        IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, processId);
        if (processHandle == IntPtr.Zero)
        {
            throw new Exception("無法打開目標進程");
        }

        // 在目標進程中分配記憶體
        IntPtr baseAddress = VirtualAllocEx(processHandle, IntPtr.Zero, (uint)dllBytes.Length, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
        if (baseAddress == IntPtr.Zero)
        {
            throw new Exception("無法在目標進程中分配記憶體");
        }

        // 將DLL寫入目標進程的記憶體
        UIntPtr bytesWritten;
        if (!WriteProcessMemory(processHandle, baseAddress, dllBytes, (uint)dllBytes.Length, out bytesWritten))
        {
            throw new Exception("無法寫入記憶體");
        }

        // 更改記憶體保護屬性為可執行
        uint oldProtect;
        if (!VirtualProtectEx(processHandle, baseAddress, (UIntPtr)dllBytes.Length, PAGE_EXECUTE_READWRITE, out oldProtect))
        {
            throw new Exception("無法更改記憶體保護屬性");
        }

        Console.WriteLine($"DLL已成功映射到記憶體地址: 0x{baseAddress.ToInt64():X}");
    }

    static void Main(string[] args)
    {
        Console.Write("請輸入目標進程ID: ");
        int processId = int.Parse(Console.ReadLine());

        Console.Write("請輸入DLL路徑: ");
        string dllPath = Console.ReadLine();

        try
        {
            MapDllToMemory(processId, dllPath);
            Console.WriteLine("DLL映射完成");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"錯誤: {ex.Message}");
        }
    }
}
