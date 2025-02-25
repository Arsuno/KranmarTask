using _Project.Source.Enemy.Configs;
using UnityEngine;

namespace _Project.Source.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private int _currentPointIndex = 0;
        private float _moveSpeed;
        
        [SerializeField] private Vector3[] _pathPoints;

        public void Initialize(EnemyConfig config)
        {
            _moveSpeed = config.MoveSpeed;
            
            _pathPoints = EnemyPatrollingPointsGenerator.GeneratePathPoints(gameObject.transform.position, config.PathPointsRadius);
        }

        public void GoPatrolling()
        {
            if (_pathPoints.Length == 0) return;

            Vector3 targetPoint = _pathPoints[_currentPointIndex];
            
            Vector3 direction = (targetPoint - transform.position).normalized;
            
            if (direction == Vector3.zero)
            {
                Debug.LogWarning("Direction is zero! Skipping LookRotation.");
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // Фиксируем Y
            }
            
            transform.position =
                Vector3.MoveTowards(transform.position, targetPoint, _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPoint) < 0.2f)
            {
                _currentPointIndex = (_currentPointIndex + 1) % _pathPoints.Length;
            }
        }
    }
}