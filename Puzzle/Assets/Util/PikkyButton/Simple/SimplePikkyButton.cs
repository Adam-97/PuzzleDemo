using UnityEngine.EventSystems;

namespace Pikky.Button
{
    public abstract class SimplePikkyButton : PikkyButton, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
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
            if (pointerIsDown || eventData.button != PointerEventData.InputButton.Left) { return; }
            pointerIsDown = true;

            PointerDown();
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