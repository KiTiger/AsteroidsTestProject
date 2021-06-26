using AsteroidsTestProject.Settings;
using AsteroidsTestProject.Utils;

namespace AsteroidsTestProject.Model
{
    public class ViewModeManager : BaseManager
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

        public ViewModeManager(GameViewConfiguration gameViewConfiguration)
        {
            this.gameViewConfiguration = gameViewConfiguration;
        }

        public override void Init(IGameManager gameManager)
        {
            base.Init(gameManager);

            currentGameViewMode = GameViewMode.Mode2D;
            currentGameViewData = FindViewData(currentGameViewMode);

            gameManager.InputManager.ChangeViewButtonClick += SwitchViewMode;
        }

        private void SwitchViewMode()
        {
            currentGameViewMode = currentGameViewMode == GameViewMode.Mode2D
                ? GameViewMode.Mode3D : GameViewMode.Mode2D;

            CurrentGameViewData = FindViewData(currentGameViewMode);
        }

        private GameViewData FindViewData(GameViewMode viewMode)
        {
            return gameViewConfiguration.visualМodes
                .Find(item => item.ViewMode == viewMode);
        }
    }
}