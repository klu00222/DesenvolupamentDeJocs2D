using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    /*
     * 
     * Invoker i ICommand són generals. Combinar amb scripts per comportament específic
     * S'ha de crear un objecte empty Invoker (o InputHandler) i posar el script
     * 
     */

    public bool ExecuteImmediate;

    public static Queue<ICommand> CommandQueue;
    public static List<ICommand> CommandHistory;
    public static int currentIndex;

    private void Awake()
    {
        CommandQueue = new Queue<ICommand>();
        CommandHistory = new List<ICommand>();

        currentIndex = 0;
    }

    private void Update()
    {
        if (ExecuteImmediate) ExecuteAll();
    }

    public static void ExecuteAll()
    {
        while (CommandQueue.Count > 0)
        {
            ICommand command = CommandQueue.Dequeue();
            command.Execute();

            CommandHistory.Add(command);
            currentIndex++;
        }
    }

    public static void AddCommand(ICommand command)
    {
        CommandQueue.Enqueue(command);

        while (CommandHistory.Count > currentIndex)
        {
            CommandHistory.RemoveAt(currentIndex);
        }
    }

    public static void Undo()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            CommandHistory[currentIndex].Undo();
        }
    }

    public static void Redo()
    {
        if (currentIndex < CommandHistory.Count)
        {
            CommandHistory[currentIndex].Execute();
            currentIndex++;
        }
    }
}
