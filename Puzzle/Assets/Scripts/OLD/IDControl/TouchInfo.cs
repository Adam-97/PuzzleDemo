using UnityEngine;

public class TouchInfo
{
    private Vector2 origin;
    private Vector2 position;
    private bool moved;

    public Vector2 Origin => origin;
    public Vector2 Position => position;
    public bool Moved => moved;

    public void SetOrigin(Vector2 origin)
    {
        this.origin = origin;
        position = origin;
        moved = false;
    }
    public void SetPosition(Vector2 position)
    {
        this.position = position;
    }
    public void SetMoved()
    {
        moved = true;
    }
}