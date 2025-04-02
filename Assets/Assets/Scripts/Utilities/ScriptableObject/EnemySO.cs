
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
    public class EnemySO : ScriptableObject
    {
        public float chaseRadius = 8f;
        public float attackSpeed = 2f;
    }
}