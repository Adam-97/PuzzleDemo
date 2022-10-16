using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Pikky.Button
{
    // For circular UIs
    public abstract class CustomComplexUIPikkyButton : PikkyButton, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Texture2D mask;
        [SerializeField] protected RectTransform rectTransform;
        [SerializeField] private bool leftClick = true;
        [SerializeField] private bool rightClick;
        [SerializeField] private bool middleClick;

        private readonly Vector3[] rectCorners = new Vector3[4];

        public void OnPointerEnter(PointerEventData eventData)
        {
            rectTransform.GetWorldCorners(rectCorners);

            ActualUpdate();
            StartCoroutine(nameof(CourutineUpdate));
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            StopCoroutine(nameof(CourutineUpdate));
            ActualUpdate();

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

        private IEnumerator CourutineUpdate()
        {
            while (true)
            {
                ActualUpdate();
                yield return null;
            }
        }
        private void ActualUpdate()
        {
            if (!pointerIsOn && IsActuallyOn())
            {
                pointerIsOn = true;
                PointerEnter();
                return;
            }

            if (pointerIsOn && !IsActuallyOn())
            {
                pointerIsOn = false;
                PointerExit();
            }
        }

        private bool IsActuallyOn()
        {
            float xPercentage = PikkyButtonUtil.CalculatePercentage(rectCorners[0].x, rectCorners[2].x, Input.mousePosition.x);
            float yPercentage = PikkyButtonUtil.CalculatePercentage(rectCorners[0].y, rectCorners[1].y, Input.mousePosition.y);

            Color color = mask.GetPixel(Mathf.RoundToInt(mask.width * xPercentage), Mathf.RoundToInt(mask.height * yPercentage));

            if (color.a == 0) { return false; }
            return true;
        }
    }
}