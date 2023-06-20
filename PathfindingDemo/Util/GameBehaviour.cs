using System.Reflection;

namespace PathfindingDemo.Util;

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
        if (startDeclareType != typeof(GameBehaviour)) //check for start event
            scheduler.StartEvent += Start;

        if (updateDeclare != typeof(GameBehaviour)) //check for update event
            scheduler.UpdateEvent += Update;
    }

    /// <summary>
    /// <inheritdoc cref="TaskScheduler.StartEvent"/>
    /// </summary>
    protected virtual void Start()
    {
        return;
    }

    /// <summary>
    /// <inheritdoc cref="TaskScheduler.UpdateEvent"/>
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
