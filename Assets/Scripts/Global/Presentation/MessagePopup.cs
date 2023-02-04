using Arman.UIManagement;
using System;
using TMPro;
using UnityEngine;

namespace Asteroids.Presentation
{
    public class MessagePopup : PopupWindow
    {
        [SerializeField] TextMeshProUGUI text = default;

        Action onConfirmAction = default;
        Action onCancelAction = default;

        public void Setup(string message, Action onConfirm, Action onCancel)
        {
            text.SetText(message);

            onConfirmAction = onConfirm;
            onCancelAction = onCancel;
        }

        public void Confirm()
        {
            this.Close();
            onConfirmAction.Invoke();
        }

        public void Cancel()
        {
            this.Close();
            onCancelAction.Invoke();
        }

        public override void OnBackButtonPressed()
        {
            Cancel();
        }
    }
}