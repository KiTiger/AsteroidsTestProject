namespace AsteroidsTestProject.Controllers
{
    public interface ISpaceObject
    {
        SpaceObjectType SpaceObjectType { get; }
        
        void CrossedBordersOfScreen();
    }
}