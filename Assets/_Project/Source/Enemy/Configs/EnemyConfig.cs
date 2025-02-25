using _Project.Source.Inventory.ItemTypesConfigs;
using UnityEngine;

namespace _Project.Source.Enemy.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("Movement")]
        public float MoveSpeed = 3f;
        public float DetectionRadius = 10f;
        public float PathPointsRadius = 25f;

        [Header("Equipment")] 
        public Weapon Weapon;
    }
}