using UnityEngine;

public class RotateCameraCommand : ICommand2
{
    public void Execute()
    {
        Camera.main.transform.Rotate(new Vector3(0, 0, 45));
    }

    public void Undo()
    {
        Camera.main.transform.Rotate(new Vector3(0, 0, -45));
    }
}
