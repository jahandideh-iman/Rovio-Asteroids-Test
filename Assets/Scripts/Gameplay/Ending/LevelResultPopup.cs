using Arman.UIManagement;
using System;
using TMPro;
using UnityEngine;


namespace Asteroids.Presentation
{
    public class LevelResultPopup : PopupWindow
    {
        [SerializeField] TextMeshProUGUI resultText = default;

        Action onContinueAction;

        public void Setup(int score, Action onContinueAction)
        {
            resultText.SetText($"Your Score: {score}");
            this.onContinueAction = onContinueAction;
        }


        public void Continue()
        {
            onContinueAction.Invoke();
        }
    }
}