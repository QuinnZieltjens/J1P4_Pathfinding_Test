namespace PathfindingDemo.Util;

internal class TaskScheduler
{
    public static TaskScheduler? Instance { get; private set; }

    public bool IsRunning { get; set; }
    public event Action? StartEvent;
    public event Action? UpdateEvent;

    private readonly Thread updateThread;

    public TaskScheduler()
    {
        //make sure that a taskScheduler doesn't already exist
        if (Instance != null)
            throw new InvalidOperationException("an instance of TaskScheduler already exists!");

        //initialize taskScheduler object
        updateThread = new Thread(() => UpdateLoop()); //create the update thread. Which calls UpdateLoop() via an anonymous function
        IsRunning = false; //set the game to not be running
        Instance = this; //set the instance to this
    }

    public void Start()
    {
        if (IsRunning)
            throw new InvalidOperationException("The TaskScheduler is already running");

        //set IsRunning to 'true'
        IsRunning = true;

        StartEvent?.Invoke(); //invoke the startEvent if it isn't null
        updateThread.Start(); //start the update thread
    }

    private void UpdateLoop()
    {
        const int DelayMilliseconds = 500; // 1000 ÷ 40 = 25fps
        DateTime startTime;
        DateTime endTime;

        while (true) //THIS IS NOT THE BEST THING TO DO
        {
            startTime = DateTime.Now;
            UpdateEvent?.Invoke();
            endTime = DateTime.Now;

            int delay = DelayMilliseconds - (endTime - startTime).Milliseconds;

            if (delay > 0)
                Thread.Sleep(delay);
        }
    }

    /// <summary>
    /// instant return, does nothing
    /// </summary>
    private static void DoNothing()
    {
        return;
    }
}
