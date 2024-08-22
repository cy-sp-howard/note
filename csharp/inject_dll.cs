BOOL InjectDLL(DWORD processId, const void* dllData, SIZE_T dllSize) {
    HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, processId);
    if (hProcess == NULL) return FALSE;

    LPVOID remoteBuffer = VirtualAllocEx(hProcess, NULL, dllSize, MEM_COMMIT, PAGE_READWRITE);
    if (remoteBuffer == NULL) {
        CloseHandle(hProcess);
        return FALSE;
    }

    if (!WriteProcessMemory(hProcess, remoteBuffer, dllData, dllSize, NULL)) {
        VirtualFreeEx(hProcess, remoteBuffer, 0, MEM_RELEASE);
        CloseHandle(hProcess);
        return FALSE;
    }

    LPTHREAD_START_ROUTINE loadLibraryAddr = (LPTHREAD_START_ROUTINE)GetProcAddress(GetModuleHandle(TEXT("kernel32.dll")), "LoadLibraryA");

    HANDLE hThread = CreateRemoteThread(hProcess, NULL, 0, loadLibraryAddr, remoteBuffer, 0, NULL);
    if (hThread == NULL) {
        VirtualFreeEx(hProcess, remoteBuffer, 0, MEM_RELEASE);
        CloseHandle(hProcess);
        return FALSE;
    }

    WaitForSingleObject(hThread, INFINITE);
    
    VirtualFreeEx(hProcess, remoteBuffer, 0, MEM_RELEASE);
    CloseHandle(hThread);
    CloseHandle(hProcess);

    return TRUE;
}
