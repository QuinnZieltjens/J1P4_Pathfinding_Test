using System.Runtime.InteropServices;

namespace PathfindingDemo.Util;

internal static class Input
{
    private const int InputDelayMilliseconds = 500;
    private static readonly Dictionary<ConsoleKey, DateTime> keypresses = new();

    public static bool GetKeyDown(ConsoleKey _key)
    {
        short keyState = GetAsyncKeyState((int)_key); //get the state of the key
        bool keyPressed = (keyState & 0x8000) != 0; //filter only for bit 15 and check whether it's value is 1 or 0

        //if the key wasn't pressed
        if (keyPressed == false)
            return false;

        if (keypresses.ContainsKey(_key))
        {
            bool timeout; //whether the key is timed out
            TimeSpan difference = keypresses[_key] - DateTime.Now; //get the difference between now and the last time the key was pressed
            TimeSpan delay = new(0, 0, 0, 0, InputDelayMilliseconds); //get the delay as a timespan

            //get whether the key is timed out
            timeout = difference >= delay;

            //if the key is timed out
            if (timeout == false)
            {
                //update when the key was last pressed
                keypresses[_key] = DateTime.Now;
                return true;
            }

            return false;
        }

        //add when the key and when it was pressed
        keypresses.Add(_key, DateTime.Now);
        return true;
    }

    // Import the GetAsyncKeyState function from user32.dll
    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int _vKey);

}
