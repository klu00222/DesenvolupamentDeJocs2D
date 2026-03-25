using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ClickRegister : MonoBehaviour      // InputHandler
{
    public GameObject StarPrefab;
    public GameObject MoonPrefab;

    /*
    void Update()
    {
        // Create required commands on inputs
        if (Input.GetMouseButtonDown(0)) CreateOrb(StarPrefab);
        if (Input.GetMouseButtonDown(1)) CreateOrb(MoonPrefab);
        if (Input.GetKeyDown(KeyCode.R)) RotateCamera();

        // Call Invoker to execute required actions
        if (Input.GetKeyDown(KeyCode.Return)) Invoker.ExecuteAll();

        if (Input.GetKey(KeyCode.LeftControl) && 
            Input.GetKeyDown(KeyCode.Z)) Invoker.Undo();

        if (Input.GetKey(KeyCode.LeftControl) && 
            Input.GetKeyDown(KeyCode.Y)) Invoker.Redo();
    }
    */

    private void OnSpawnStar()
    {
        CreateOrb(StarPrefab);
    }

    private void OnSpawnMoon()
    {
        CreateOrb(MoonPrefab);
    }

    private void OnRotate()
    {
        RotateCamera();
    }

    private void OnExecute()
    {
        Invoker.ExecuteAll();
    }

    private void OnUndo()
    {
        Invoker.Undo();
    }

    private void OnRedo()
    {
        Invoker.Redo();
    }

    public static void CreateOrb(GameObject prefab)
    {
        var clickPosition = GetClickPosition();
        var color = GetRandomColor();
      
        if (clickPosition != null)
        {
            var command = new CreateOrbCommand(prefab, (Vector2)clickPosition, color);
            Invoker.AddCommand(command);
        }
    }

    private void RotateCamera()
    {
        var command = new RotateCameraCommand();
        Invoker2.AddCommand(command);
    }

    private static Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1);
    }

    private static Vector2? GetClickPosition()
    {
        // Convert mouse coordinates to world coordinates
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider != null)
        {
            return hit.point;
        }

        return null;
    }
}
