using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public void Clicked()
    {
        Debug.Log(string.Concat("Clicked: ", gameObject.name));
    }
}