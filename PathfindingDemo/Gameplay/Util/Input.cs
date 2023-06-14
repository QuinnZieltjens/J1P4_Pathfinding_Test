namespace PathfindingDemo.Gameplay.Util;

internal class Input
{
    public static bool KeyPressed(ConsoleKey _key)
    {
        //if no key is available, return false
        if (Console.KeyAvailable == false)
            return false;
        
        //gets the key info from the pressed key
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        
        //return if keyInfo.Key is equal to _key
        return keyInfo.Key == _key;
    }
}
