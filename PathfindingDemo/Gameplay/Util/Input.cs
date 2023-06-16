using System.Runtime.InteropServices;

namespace PathfindingDemo.Gameplay.Util;

internal static class Input
{
    private const int InputDelayMilliseconds = 500;
    private static readonly Dictionary<ConsoleKey, DateTime> keypresses = new();

    public static bool GetKeyDown(ConsoleKey _key)
    {
        short keyState = GetAsyncKeyState((int)_key);
        bool keyPressed = (keyState & 0x8000) != 0;

        if (keyPressed == false)
            return false;

        if (keypresses.ContainsKey(_key))
        {
            bool timeout;
            TimeSpan difference = (keypresses[_key] - DateTime.Now);
            TimeSpan delay = new(0, 0, 0, 0, InputDelayMilliseconds);

            timeout = difference >= delay;
            if (timeout == false)
            {
                keypresses[_key] = DateTime.Now;
                return true;
            }

            return false;
        }

        keypresses.Add(_key, DateTime.Now);
        return true;
    }

    // Import the GetAsyncKeyState function from user32.dll
    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int _vKey);

}
