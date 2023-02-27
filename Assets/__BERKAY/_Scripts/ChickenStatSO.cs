using UnityEngine;

namespace Berkay
{
    [CreateAssetMenu(fileName = "New Stat File", menuName = "Stat/New Player Stat")]
    public class ChickenStatSO : ScriptableObject
    {
        [Range(1, 10), SerializeField] private float level;
        public float Level => level;

        [Range(3, 10), SerializeField] private int maxWormStackCount;
        public int MaxWormStackCount => maxWormStackCount;
        
        [Range(1, 10), SerializeField] private float moveSpeed;
        public float MoveSpeed => moveSpeed;
        
        [Range(1, 10), SerializeField] private float onTakeHitDamage;
        public float OnTakeHitDamage => onTakeHitDamage;
        
        [SerializeField] private Vector3 onHitForce;
        public Vector3 OnHitForce => onHitForce;
        
        [Range(1, 10), SerializeField] private float afterHitStandUpTime;
        public float AfterHitStandUpTime => afterHitStandUpTime;
        
    }
}