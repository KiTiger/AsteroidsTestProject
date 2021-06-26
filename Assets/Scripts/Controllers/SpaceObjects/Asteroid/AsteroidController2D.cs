using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class AsteroidController2D : BaseAsteroidController
    {
        [SerializeField] private float rotationMaxSpeed;

        private Vector3 localEulerAngles;
        private float directionOfRotation;

        protected override void Prepare()
        {
            directionOfRotation = Random.Range(-rotationMaxSpeed, rotationMaxSpeed);
            localEulerAngles = new Vector3(0, 0, Random.Range(0, 360f));
            transform.localEulerAngles = localEulerAngles;
        }

        protected override void Update()
        {
            base.Update();
            localEulerAngles.z += directionOfRotation * Time.deltaTime;
            transform.localEulerAngles = localEulerAngles;
        }
    }
}