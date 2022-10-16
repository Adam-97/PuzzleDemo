using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public partial class TouchInput
    {
        [SerializeField] private TMP_Text clickedText0;
        [SerializeField] private TMP_Text clickedText1;
        [SerializeField] private TMP_Text clickedText2;
        [SerializeField] private TMP_Text clickedText3;

        private void HandleClick()
        {
            List<Touch> missingTouches = GetMissingTouches();

            // These are the clicks in a really simple solution...
            HandleText(missingTouches);
        }

        // HandleClicks...
        private void HandleText(List<Touch> missingTouches)
        {
            // 0
            if (missingTouches.Count < 1) { TextReset(4); return; }
            clickedText0.text = string.Concat("Clicked at: X - ", missingTouches[0].position.x.ToString("0.000"), ", Y - ", missingTouches[0].position.y.ToString("0.000"));

            // 1
            if (missingTouches.Count < 2) { TextReset(3); return; }
            clickedText1.text = string.Concat("Clicked at: X - ", missingTouches[1].position.x.ToString("0.000"), ", Y - ", missingTouches[1].position.y.ToString("0.000"));

            // 2
            if (missingTouches.Count < 3) { TextReset(2); return; }
            clickedText2.text = string.Concat("Clicked at: X - ", missingTouches[2].position.x.ToString("0.000"), ", Y - ", missingTouches[2].position.y.ToString("0.000"));

            // 3
            if (missingTouches.Count < 4) { TextReset(1); return; }
            clickedText3.text = string.Concat("Clicked at: X - ", missingTouches[3].position.x.ToString("0.000"), ", Y - ", missingTouches[3].position.y.ToString("0.000"));
        }
        private void TextReset(int reset)
        {
            clickedText3.text = Input.touchCount.ToString();

            // switch (reset)
            // {
            //     case 4:
            //         clickedText0.text = "null";
            //         clickedText1.text = "null";
            //         clickedText2.text = "null";
            //         clickedText3.text = "null";
            //         break;
            //     case 3:
            //         clickedText1.text = "null";
            //         clickedText2.text = "null";
            //         clickedText3.text = "null";
            //         break;
            //     case 2:
            //         clickedText2.text = "null";
            //         clickedText3.text = "null";
            //         break;
            //     case 1:
            //         clickedText3.text = "null";
            //         break;
            // }
        }




        // GetMissingTouches...
        private List<Touch> GetMissingTouches()
        {
            List<int> previousTouchIDs = GetPreviousTouchIDs();
            List<int> missingTouchIDs = GetMissingTouchIDs(previousTouchIDs);
            return GetMissingTouches(missingTouchIDs);
        }
        private List<Touch> GetMissingTouches(List<int> missingTouchIDs)
        {
            if (missingTouchIDs.Count == 0) { return new List<Touch>(); }

            List<Touch> missingTouches = new List<Touch>();

            for (int i = 0; i < previousTouches.Length; i++)
            {
                if (!missingTouchIDs.Contains(previousTouches[i].fingerId)) { continue; }
                missingTouches.Add(previousTouches[i]);
            }

            return missingTouches;
        }
        private List<int> GetMissingTouchIDs(List<int> previousTouchIDs)
        {
            if (previousTouchIDs.Count == 0) { return new List<int>(); }

            for (int i = 0; i < currentTouches.Length; i++)
            {
                if (!previousTouchIDs.Contains(currentTouches[i].fingerId)) { continue; }
                previousTouchIDs.Remove(currentTouches[i].fingerId);
            }

            return previousTouchIDs;
        }
        private List<int> GetPreviousTouchIDs()
        {
            List<int> previousTouchIDs = new List<int>();

            for (int i = 0; i < previousTouches.Length; i++)
            {
                previousTouchIDs.Add(previousTouches[i].fingerId);
            }

            return previousTouchIDs;
        }
    }
}