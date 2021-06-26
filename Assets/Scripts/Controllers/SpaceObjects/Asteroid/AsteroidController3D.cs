using UnityEngine;

namespace AsteroidsTestProject.Controllers
{
    public class AsteroidController3D : BaseAsteroidController
    {
        [SerializeField] private float rotationMaxSpeed;

        private Vector3 localEulerAngles;
        private Vector3 directionOfRotation;

        protected override void Prepare()
        {
            directionOfRotation.x = GetRandomRotationSpeed();
            directionOfRotation.y = GetRandomRotationSpeed();
            directionOfRotation.z = GetRandomRotationSpeed();
            localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
            transform.localEulerAngles = localEulerAngles;
        }

        protected override void Update()
        {
            base.Update();
            localEulerAngles += directionOfRotation * Time.deltaTime;
            transform.localEulerAngles = localEulerAngles;
        }

        private float GetRandomRotationSpeed()
        {
            return Random.Range(-rotationMaxSpeed, rotationMaxSpeed);
        }
    }
}