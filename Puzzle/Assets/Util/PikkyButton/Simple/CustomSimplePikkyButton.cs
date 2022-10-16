using UnityEngine;
using UnityEngine.EventSystems;

namespace Pikky.Button
{
    public abstract class CustomSimplePikkyButton : PikkyButton, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private bool leftClick = true;
        [SerializeField] private bool rightClick;
        [SerializeField] private bool middleClick;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (pointerIsOn) { return; }
            pointerIsOn = true;

            PointerEnter();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            if (!pointerIsOn) { return; }
            pointerIsOn = false;

            PointerExit();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (pointerIsDown) { return; }

            if (leftClick && eventData.button == PointerEventData.InputButton.Left ||
                rightClick && eventData.button == PointerEventData.InputButton.Right ||
                middleClick && eventData.button == PointerEventData.InputButton.Middle)
            {
                pointerIsDown = true;
                PointerDown();
            }
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (!pointerIsDown) { return; }
            pointerIsDown = false;

            PointerUp();

            if (!pointerIsOn) { return; }
            ClickedOn();
        }
    }
}