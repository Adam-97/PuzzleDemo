using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewTouchControl : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private CameraControl cameraControl;

    private readonly Vector2[] touchArea = new Vector2[2];
    private readonly TouchInfo[] touchInfos = new TouchInfo[2];
    private readonly List<int> fingerIDs = new List<int>();
    private readonly Dictionary<int, int> fingerIDToIndex = new Dictionary<int, int>();

    [SerializeField] private TMP_Text countText;

    private void Start()
    {
        Application.targetFrameRate = 60;
        GetTouchArea();
        for (int i = 0; i < touchInfos.Length; i++)
        {
            touchInfos[i] = new TouchInfo();
        }
    }
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            switch (Input.touches[i].phase)
            {
                case TouchPhase.Began:
                    HandleBegin(i);
                    break;
                case TouchPhase.Moved:
                    HandleMovement(i);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    HandleEnded(i);
                    break;
            }
        }

        countText.text = fingerIDs.Count.ToString();
    }

    private void HandleBegin(int touchIndex)
    {
        Touch touch = Input.GetTouch(touchIndex);

        if (fingerIDs.Count == 2) { return; }

        if (InTouchArea(touch.position))
        {
            fingerIDToIndex[touch.fingerId] = fingerIDs.Count;
            fingerIDs.Add(touch.fingerId);
            touchInfos[fingerIDToIndex[touch.fingerId]].SetOrigin(touch.position);
        }
    }
    private void HandleMovement(int touchIndex)
    {
        Touch touch = Input.GetTouch(touchIndex);

        if (!fingerIDs.Contains(touch.fingerId)) { return; }

        if (!touchInfos[fingerIDToIndex[touch.fingerId]].Moved && Vector2.Distance(touchInfos[fingerIDToIndex[touch.fingerId]].Origin, touch.position) > 10)
        {
            touchInfos[fingerIDToIndex[touch.fingerId]].SetMoved();
        }

        if (!touchInfos[fingerIDToIndex[touch.fingerId]].Moved) { return; }

        touchInfos[fingerIDToIndex[touch.fingerId]].SetPosition(touch.position);

        if (fingerIDs.Count == 1)
        {
            cameraControl.OnDrag(touch.deltaPosition);
        }
        else if (fingerIDs.Count == 2)
        {
            touchInfos[0].SetMoved();
            touchInfos[1].SetMoved();

            if (fingerIDToIndex[touch.fingerId] == 0)
            {
                cameraControl.OnZoom(touch.deltaPosition, touch.position, touchInfos[1].Position);
            }
            else if (fingerIDToIndex[touch.fingerId] == 1)
            {
                cameraControl.OnZoom(touch.deltaPosition, touch.position, touchInfos[0].Position);
            }
        }
    }
    private void HandleEnded(int touchIndex)
    {
        Touch touch = Input.GetTouch(touchIndex);

        if (!fingerIDs.Contains(touch.fingerId)) { return; }
        fingerIDs.Remove(touch.fingerId);

        if (touchInfos[fingerIDToIndex[touch.fingerId]].Moved) { return; }

        if (!Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out RaycastHit hit, 100)) { return; }
        if (!hit.transform.gameObject.TryGetComponent(out PuzzleButton puzzleButton)) { return; }
        puzzleButton.Clicked();
    }

    private void GetTouchArea()
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        touchArea[0] = corners[0];
        touchArea[1] = corners[2];
    }
    private bool InTouchArea(Vector2 position)
    {
        if (position.x < touchArea[0].x) { return false; }
        if (position.y < touchArea[0].y) { return false; }
        if (touchArea[1].x < position.x) { return false; }
        if (touchArea[1].y < position.y) { return false; }
        return true;
    }
}