using UnityEngine;
using TMPro;

public class InputChecker : MonoBehaviour
{
    // Mouse...
    [SerializeField] private TMP_Text mouseLeftClickText;
    [SerializeField] private TMP_Text mouseRightClickText;
    [SerializeField] private TMP_Text mouseMiddleClickText;
    [SerializeField] private TMP_Text mousePositionText;

    // Touch...
    [SerializeField] private TMP_Text touchCountText;

    // 0...
    [SerializeField] private TMP_Text touch0Phase;
    [SerializeField] private TMP_Text touch0ID;
    [SerializeField] private TMP_Text touch0Position;

    // 1...
    [SerializeField] private TMP_Text touch1Phase;
    [SerializeField] private TMP_Text touch1ID;
    [SerializeField] private TMP_Text touch1Position;

    // 2...
    [SerializeField] private TMP_Text touch2Phase;
    [SerializeField] private TMP_Text touch2ID;
    [SerializeField] private TMP_Text touch2Position;

    // 3...
    [SerializeField] private TMP_Text touch3Phase;
    [SerializeField] private TMP_Text touch3ID;
    [SerializeField] private TMP_Text touch3Position;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = true;
    }

    private void Update()
    {
        // Mouse...
        MouseButtonDown();
        MouseButtonUp();
        MousePosition();

        // Touch...
        TouchCount();
        Touch0();
        Touch1();
        Touch2();
        Touch3();
    }

    // Mouse...
    private void MouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseLeftClickText.text = "Mouse Left Click: Down";
        }
        if (Input.GetMouseButtonDown(1))
        {
            mouseRightClickText.text = "Mouse Right Click: Down";
        }
        if (Input.GetMouseButtonDown(2))
        {
            mouseMiddleClickText.text = "Mouse Middle Click: Down";
        }
    }
    private void MouseButtonUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mouseLeftClickText.text = "Mouse Left Click: Up";
        }
        if (Input.GetMouseButtonUp(1))
        {
            mouseRightClickText.text = "Mouse Right Click: Up";
        }
        if (Input.GetMouseButtonUp(2))
        {
            mouseMiddleClickText.text = "Mouse Middle Click: Up";
        }
    }
    private void MousePosition()
    {
        mousePositionText.text = string.Concat("Mouse Position: X - ", Input.mousePosition.x.ToString("0.000"), ", Y - ", Input.mousePosition.y.ToString("0.000"));
    }

    // Touch...
    private void TouchCount()
    {
        touchCountText.text = string.Concat("Touch Count: ", Input.touchCount);
    }
    private void Touch0()
    {
        if (Input.touchCount < 1) { ResetTouch0(); return; }

        Touch touch = Input.touches[0];

        touch0Phase.text = string.Concat("Touch 0 Phase: ", touch.phase);
        touch0ID.text = string.Concat("Touch 0 ID: ", touch.fingerId);
        touch0Position.text = string.Concat("Touch 0 Position: X - ", touch.position.x.ToString("0.000"), ", Y - ", touch.position.y.ToString("0.000"));
    }
    private void ResetTouch0()
    {
        touch0Phase.text = "Touch 0 Phase: Null";
        touch0ID.text = "Touch 0 ID: Null";
        touch0Position.text = "Touch 0 Position: Null";
    }
    private void Touch1()
    {
        if (Input.touchCount < 2) { ResetTouch1(); return; }

        Touch touch = Input.touches[1];

        touch1Phase.text = string.Concat("Touch 1 Phase: ", touch.phase);
        touch1ID.text = string.Concat("Touch 1 ID: ", touch.fingerId);
        touch1Position.text = string.Concat("Touch 1 Position: X - ", touch.position.x.ToString("0.000"), ", Y - ", touch.position.y.ToString("0.000"));
    }
    private void ResetTouch1()
    {
        touch1Phase.text = "Touch 1 Phase: Null";
        touch1ID.text = "Touch 1 ID: Null";
        touch1Position.text = "Touch 1 Position: Null";
    }
    private void Touch2()
    {
        if (Input.touchCount < 3) { ResetTouch2(); return; }

        Touch touch = Input.touches[2];

        touch2Phase.text = string.Concat("Touch 2 Phase: ", touch.phase);
        touch2ID.text = string.Concat("Touch 2 ID: ", touch.fingerId);
        touch2Position.text = string.Concat("Touch 2 Position: X - ", touch.position.x.ToString("0.000"), ", Y - ", touch.position.y.ToString("0.000"));
    }
    private void ResetTouch2()
    {
        touch2Phase.text = "Touch 2 Phase: Null";
        touch2ID.text = "Touch 2 ID: Null";
        touch2Position.text = "Touch 2 Position: Null";
    }
    private void Touch3()
    {
        if (Input.touchCount < 4) { ResetTouch3(); return; }

        Touch touch = Input.touches[3];

        touch3Phase.text = string.Concat("Touch 3 Phase: ", touch.phase);
        touch3ID.text = string.Concat("Touch 3 ID: ", touch.fingerId);
        touch3Position.text = string.Concat("Touch 3 Position: X - ", touch.position.x.ToString("0.000"), ", Y - ", touch.position.y.ToString("0.000"));
    }
    private void ResetTouch3()
    {
        touch3Phase.text = "Touch 3 Phase: Null";
        touch3ID.text = "Touch 3 ID: Null";
        touch3Position.text = "Touch 3 Position: Null";
    }
}