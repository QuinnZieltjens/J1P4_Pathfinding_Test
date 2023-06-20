using System.Reflection;

namespace PathfindingDemo;

internal abstract class GameBehaviour
{
    public GameBehaviour()
    {
        //get the task scheduler's instance (if instance == null, throw NullReferenceException)
        TaskScheduler scheduler = TaskScheduler.Instance ?? throw new NullReferenceException("The TaskScheduler didn't have an instance");

        //get the declaring types of the methods
        Type startDeclareType = GetMethodDeclaringType(nameof(Start));
        Type updateDeclare = GetMethodDeclaringType(nameof(Update));


        //insure that the methods only listen to the event if they haven't been declared by this class
        if (startDeclareType != typeof(GameBehaviour))
            scheduler.StartEvent += Start;

        if (updateDeclare != typeof(GameBehaviour))
            scheduler.UpdateEvent += Update;
    }

    /// <summary>
    /// is called before the first frame
    /// </summary>
    protected virtual void Start()
    {
        return;
    }

    /// <summary>
    /// is called every frame
    /// </summary>
    protected virtual void Update()
    {
        return;
    }

    private Type GetMethodDeclaringType(string _methodName)
    {
        Type instanceType = GetType(); //get the type of the current instance
        MethodInfo? methodInfo = instanceType.GetMethod(_methodName); //get the method with the given methodName

        //return the method's declared type, otherwise return the instance type
        return methodInfo?.DeclaringType ?? instanceType;
    }
}
