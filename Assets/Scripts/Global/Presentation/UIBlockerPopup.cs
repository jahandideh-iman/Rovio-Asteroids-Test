using Arman.UIManagement;

namespace Asteroids.Presentation
{
    public class UIBlockerPopup : PopupWindow
    {
        public override void OnFocused()
        {
            uiManager.BackgroundPanel().SetAlpha(0f);
        }
    }
}