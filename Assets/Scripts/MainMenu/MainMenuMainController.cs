
using System;

namespace Asteroids.Game
{
    public class MainMenuMainController : MainGameController
    {
        Action goToLevelAction;
        Action exitAppAction;

        public MainMenuMainController(Action goToLevelAction, Action exitAppAction)
        {
            this.goToLevelAction = goToLevelAction;
            this.exitAppAction = exitAppAction;
        }

        public void GoToLevel()
        {
            goToLevelAction.Invoke();
        }

        public void ExitApp()
        {
            exitAppAction.Invoke();
        }
    }
}