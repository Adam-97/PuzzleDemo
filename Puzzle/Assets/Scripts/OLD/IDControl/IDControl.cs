using UnityEngine;
using TMPro;

public class IDControl : MonoBehaviour
{
    [SerializeField] private TMP_Text[] idStatusTexts;

    private TouchInfo[] touchInfos;

    private void Start()
    {
        Application.targetFrameRate = 60;

        touchInfos = new TouchInfo[4];
        for (int i = 0; i < touchInfos.Length; i++)
        {
            touchInfos[i] = new TouchInfo();
        }
    }
    private void Update()
    {
        
    }

    private void HandleOneTouch()
    {
        // If its moving its a drag, if it did not move, its a click...
        // Need to look into button...
    }



    private void OldUpdate()
    {
        // Handle Origins...
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].fingerId >= idStatusTexts.Length) { continue; }

            switch (Input.touches[i].phase)
            {
                case TouchPhase.Began:
                    HandleBegin(i);
                    break;
                case TouchPhase.Moved:
                    HandleMovement(i);
                    break;
                case TouchPhase.Ended:
                    HandleEnded(i);
                    break;
            }
        }
    }

    private void HandleBegin(int touchIndex)
    {
        Touch touch = Input.GetTouch(touchIndex);

        touchInfos[touch.fingerId].SetOrigin(touch.position);
        idStatusTexts[touch.fingerId].text = string.Concat("Touch ", touch.fingerId, " Origin: X - ", touch.position.x.ToString("0.000"), ", Y - ", touch.position.y.ToString("0.000"));
    }
    private void HandleMovement(int touchIndex)
    {
        Touch touch = Input.GetTouch(touchIndex);

        if (Vector2.Distance(touchInfos[touch.fingerId].Origin, touch.position) > 10)
        {
            touchInfos[touch.fingerId].SetMoved();
            idStatusTexts[touch.fingerId].text = string.Concat("Touch ", touch.fingerId, " Dragging.");
        }
    }
    private void HandleEnded(int touchIndex)
    {
        Touch touch = Input.GetTouch(touchIndex);

        if (touchInfos[touch.fingerId].Moved)
        {
            idStatusTexts[touch.fingerId].text = string.Concat("Touch ", touch.fingerId, " Dragged.");
            return;
        }

        idStatusTexts[touch.fingerId].text = string.Concat("Touch ", touch.fingerId, " Clicked.");
    }
}