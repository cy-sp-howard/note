## monogame
```csharp
// 無標題視窗
this.Window.IsBorderless = true;

// 取得視窗尺寸
[DllImport("user32.dll", SetLastError = true)]
  private static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);

// 設定視窗至上層
[DllImport("user32.dll")]
  private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
```
