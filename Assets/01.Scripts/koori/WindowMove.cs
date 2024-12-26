using System.Runtime.InteropServices;
using UnityEngine;

public static class WindowMove
{
    [DllImport("user32.dll")] static extern int GetForegroundWindow();
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    static Vector2 curPos;

    public static void Move(Vector2 pos)
    {
        curPos += new Vector2(-pos.x, pos.y);
        curPos = new Vector2(Mathf.Clamp(curPos.x, 0, Screen.currentResolution.width - Screen.width)
            , Mathf.Clamp(curPos.y, 0, Screen.currentResolution.height - Screen.height));
#if !UNITY_EDITOR
        SetWindowPos(GetForegroundWindow(), 0, (int)curPos.x, (int)curPos.y, 0, 0, 0x0001 | 0x0004);
#endif
    }
}
