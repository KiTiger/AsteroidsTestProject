namespace AsteroidsTestProject.Model
{
    public abstract class BaseManager
    {
        protected IGameManager gameManager;

        public virtual void Init(IGameManager gameManager)
        {
            this.gameManager = gameManager;
        }
    }
}