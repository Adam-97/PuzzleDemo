using UnityEngine;

namespace Pikky.Button
{
    public abstract class PikkyButton : MonoBehaviour
    {
        protected bool pointerIsOn = false;
        protected bool pointerIsDown = false;

        /// <summary>
        /// Called when pointer enters button.
        /// </summary>
        protected abstract void PointerEnter();
        /// <summary>
        /// Called when pointer exits button.
        /// </summary>
        protected abstract void PointerExit();
        /// <summary>
        /// Called when pointer pressed down on button.
        /// </summary>
        protected abstract void PointerDown();
        /// <summary>
        /// Called when pointer released on button.
        /// </summary>
        protected abstract void PointerUp();
        /// <summary>
        /// Called when pointer clicked on button.
        /// </summary>
        protected abstract void ClickedOn();
    }
}