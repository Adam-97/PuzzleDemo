using System.Xml;
using UnityEngine;
using TMPro;

public class TouchZoom : MonoBehaviour
{
    private TouchInfo[] touchInfos;

    [SerializeField] private Transform touchField;
    [SerializeField] private TMP_Text zoomText;

    private void Start()
    {
        touchInfos = new TouchInfo[2];
        for (int i = 0; i < touchInfos.Length; i++)
        {
            touchInfos[i] = new TouchInfo();
        }
    }
    private void Update()
    {
        HandleOrigins();
        if (Input.touchCount < 2) { zoomText.text = "null"; return; }
        HandleZoom();
    }

    private void HandleOrigins()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].fingerId >= touchInfos.Length) { continue; }

            switch (Input.touches[i].phase)
            {
                case TouchPhase.Began:
                    HandleBegin(i);
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
    }
    private void HandleEnded(int touchIndex)
    {
        Touch touch = Input.GetTouch(touchIndex);
        touchInfos[touch.fingerId].SetOrigin(touch.position);
    }
    private void HandleZoom()
    {
        zoomText.text = "Zooming";
    }
}