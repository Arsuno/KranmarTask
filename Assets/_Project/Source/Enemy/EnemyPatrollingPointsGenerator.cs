using UnityEngine;

namespace _Project.Source.Enemy
{
    public static class EnemyPatrollingPointsGenerator
    {
        public static Vector3[] GeneratePathPoints(Vector3 origin, float offset)
        {
            return new Vector3[]
            {
                new Vector3(origin.x + offset, origin.y, origin.z + offset),
                new Vector3(origin.x + offset, origin.y, origin.z - offset),
                new Vector3(origin.x - offset, origin.y, origin.z - offset),
                new Vector3(origin.x - offset, origin.y, origin.z + offset)
            };
        }
    }
}