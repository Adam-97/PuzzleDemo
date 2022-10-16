using UnityEngine;

namespace Assets.Scripts
{
    public partial class TouchInput : MonoBehaviour
    {
        private Touch[] currentTouches = new Touch[0];
        private Touch[] previousTouches = new Touch[0];

        private void Update()
        {
            currentTouches = Input.touches;

            HandleTouches();

            previousTouches = Input.touches;
        }

        private void HandleTouches()
        {
            // Lets first go for a simple click...
            HandleClick();
        }
    }
}