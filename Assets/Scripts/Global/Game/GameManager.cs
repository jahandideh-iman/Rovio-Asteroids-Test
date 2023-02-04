using Arman.Foundation.Core.ServiceLocating;
using UnityEngine.SceneManagement;

namespace Asteroids.Game
{
    public class GameManager : Service
    {
        public MainGameController MainController { get; private set; }

        public void GoToMainMenu()
        {
            MainController = new MainMenuMainController(
                goToLevelAction: GoToLevelScene,
                exitAppAction: ExitApp);

            SceneManager.LoadScene("MainMenuScene");
        }

        public void GoToLevelScene()
        {

            MainController = new LevelMainController(
                exitLevelAction: GoToMainMenu);

            SceneManager.LoadScene("LevelScene");
        }

        public void ExitApp()
        {
#if !UNITY_EDITOR
            Application.Quit();
#else
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}