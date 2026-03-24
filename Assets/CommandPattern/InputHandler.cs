using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private void OnUndo()
    {
        Invoker.Undo();
    }

    private void OnRedo()
    {
        Invoker.Redo();
    }

    private void OnSpace()
    {
        ChangeColors();
    }

    private void OnReturn()
    {
        Invoker.ExecuteAll();
    }

    private void ChangeColors()
    {
        List<ColorEntity> circles = EntityManager.GetRandomEntities(10);

        ColorManager command = new(circles, Random.ColorHSV());
        Invoker.AddCommand(command);
    }
}
