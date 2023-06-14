namespace PathfindingDemo;

internal abstract class GameBehaviour
{

    private static event Action StartEvent;
    private static event Action UpdateEvent;

    private static Thread UpdateThread { get; }

    private bool gameRunning = false;


    static GameBehaviour()
    {
        StartEvent += DoNothing;
        UpdateEvent += DoNothing;

        UpdateThread = new Thread(UpdateLoop);
    }

    public GameBehaviour()
    {
        StartEvent += Start;
        UpdateEvent += Update;
    }

    public static void StartGame(GameBehaviour _game)
    {
        if (_game.gameRunning == true)
            throw new Exception("the game is already running");

        _game.StartGame();
    }

    /// <summary>
    /// is called before the first frame
    /// </summary>
    protected virtual void Start() => DoNothing();

    /// <summary>
    /// is called every frame
    /// </summary>
    protected virtual void Update() => DoNothing();

    /// <summary>
    /// immediately returns
    /// </summary>
    private static void DoNothing()
    {
        return;
    }

    /// <summary>
    /// the loop for invoking <see cref="UpdateEvent"/> with a set delay
    /// </summary>
    private static void UpdateLoop()
    {
        const int DelayMilliseconds = 40; // 1000 ÷ 40 = 25fps
        DateTime startTime;
        DateTime endTime;

        while (true) //THIS IS NOT THE BEST THING TO DO
        {
            startTime = DateTime.Now;
            UpdateEvent.Invoke();
            endTime = DateTime.Now;

            int delay = DelayMilliseconds - (endTime - startTime).Milliseconds;

            if (delay > 0)
                Thread.Sleep(delay);
        }
    }

    /// <summary>
    /// starts the game
    /// </summary>
    private void StartGame()
    {
        gameRunning = true;
        StartEvent.Invoke(); //invoke the start event
        UpdateThread.Start(); //start the update loop

        //sleep indefinitely
        Thread.Sleep(-1);
    }
}
