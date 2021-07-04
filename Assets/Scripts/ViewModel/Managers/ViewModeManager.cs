using AsteroidsTestProject.GameEngine;
using AsteroidsTestProject.GameEngine.Utils;
using AsteroidsTestProject.Settings;
using System.Linq;

namespace AsteroidsTestProject.ViewModel
{
    public class ViewModeManager
    {
        private GameViewConfiguration gameViewConfiguration;
        private GameViewData currentGameViewData;
        private GameViewMode currentGameViewMode;

        public GameViewData CurrentGameViewData
        {
            get => currentGameViewData;
            private set
            {
                currentGameViewData = value;
                onChangeViewData.SafeInvoke(currentGameViewData);
            }
        }

        public event Block<GameViewData> onChangeViewData;

        public ViewModeManager(InputManager inputManager, GameViewConfiguration gameViewConfiguration)
        {
            this.gameViewConfiguration = gameViewConfiguration;

            currentGameViewMode = GameViewMode.Mode2D;
            currentGameViewData = FindViewData(currentGameViewMode);

            inputManager.ChangeViewButtonClick += SwitchViewMode;
        }

        private void SwitchViewMode()
        {
            currentGameViewMode = currentGameViewMode == GameViewMode.Mode2D
                ? GameViewMode.Mode3D : GameViewMode.Mode2D;

            CurrentGameViewData = FindViewData(currentGameViewMode);
        }

        private GameViewData FindViewData(GameViewMode viewMode)
        {
            return gameViewConfiguration.VisualМodes
                .Find(item => item.ViewMode == viewMode);
        }
    }
}