using UnityEngine;
using UnityEngine.EventSystems;

namespace Pikky.Button
{
    public abstract class PikkyDragButton : PikkyButton, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        protected bool dragging = false;

        public void OnPointerEnter(PointerEventData eventData)
        {
            pointerIsOn = true;
            PointerEnter();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            pointerIsOn = false;
            PointerExit();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            pointerIsDown = true;
            PointerDown();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            pointerIsDown = false;
            PointerUp();

            if (pointerIsOn && !dragging)
            {
                ClickedOn();
            }

            dragging = false;
        }
        public void OnDrag(PointerEventData eventData)
        {
            dragging = true;
            PointerDrag(eventData.delta);
        }

        /// <summary>
        /// Called when pointer is dragging.
        /// </summary>
        /// <param name="delta"></param>
        protected abstract void PointerDrag(Vector2 delta);
    }
}