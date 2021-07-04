using System;

namespace AsteroidsTestProject.GameEngine.Utils
{
    public static class RandomUtils
    {
        private static Random rand;

        private static Random Random => rand ?? (rand = new Random());

        public static float Range(float min, float max)
        {
            var range = max - min;
            var value = (float)Random.NextDouble();
            return min + range * value;
        }
    }
}