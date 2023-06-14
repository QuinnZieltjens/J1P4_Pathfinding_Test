using System.Runtime.InteropServices;

namespace PathfindingDemo.Gameplay.Util;

internal static class Input
{
    // Import the GetAsyncKeyState function from user32.dll
    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(int _vKey);

    private static ConsoleKey? lastDetectedKey = null;

    public static bool KeyPressed(ConsoleKey _key)
    {
        return (GetAsyncKeyState((int)_key) & 0x8000) != 0;
    }
}
