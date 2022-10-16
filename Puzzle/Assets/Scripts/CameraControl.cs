using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 wantedPosition;

    private float xMult;
    private float yMult;

    private void Start()
    {
        xMult = 20.53f / Screen.width;
        yMult = 11.55f / Screen.height;

        wantedPosition = transform.position;
        StartCoroutine(Enumerator());
    }

    public void OnDrag(Vector2 delta)
    {
        // Debug.Log(string.Concat("Drag: ", delta.x, " - ", delta.y));
        wantedPosition -= new Vector3(delta.x * xMult, delta.y * yMult, 0f);
    }
    public void OnZoom(Vector2 delta, Vector2 thisPosition, Vector2 otherPosition)
    {
        Vector2 oldPosition = thisPosition - delta;

        float oldDistance = Vector2.Distance(oldPosition, otherPosition);
        float newDistance = Vector2.Distance(thisPosition, otherPosition);

        float diff = oldDistance - newDistance;

        wantedPosition = new Vector3(wantedPosition.x, wantedPosition.y, wantedPosition.z - diff * 0.01f);
    }

    private IEnumerator Enumerator()
    {
        while (true)
        {
            _transform.position += (wantedPosition - _transform.position) * 0.1f;
            yield return null;
        }
    }
}