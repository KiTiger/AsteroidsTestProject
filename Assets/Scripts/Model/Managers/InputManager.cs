using AsteroidsTestProject.Utils;

namespace AsteroidsTestProject.Model
{
    public class InputManager : BaseManager
    {
        private InputControls inputControls;

        public bool UpButtonPressed { get; private set; }
        public float XAxis { get; private set; }
        
        public event Block ShotButtonClick;
        public event Block LaserButtonClick;
        public event Block ChangeViewButtonClick;

        public InputManager()
        {
            inputControls = new InputControls();

            inputControls.Player.Up.started += ctx => UpButtonPressed = true;
            inputControls.Player.Up.canceled += ctx => UpButtonPressed = false;

            inputControls.Player.xAxis.performed += ctx => XAxis = ctx.ReadValue<float>();
            inputControls.Player.xAxis.canceled += ctx => XAxis = 0;

            inputControls.Player.Laser.started += ctx => LaserButtonClick.SafeInvoke();
            inputControls.Player.Shot.started += ctx => ShotButtonClick.SafeInvoke();

            inputControls.World.ChangeViewState.started += ctx => ChangeViewButtonClick.SafeInvoke();

            inputControls.Enable();
        }

    }
}