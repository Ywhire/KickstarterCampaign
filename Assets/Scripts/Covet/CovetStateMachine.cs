using OpenSystemGames.Core;
using UnityEngine;
namespace OpenSystemGames.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CovetStateMachine : StateMachine
    {
        private const string playerTag = "Player";
        
        public bool DebugLogOption;

        [field: SerializeField, Min(0)]
        public float Speed { get; private set; }

        [field: SerializeField]
        public Rigidbody2D Rigidbody2D { get; private set; }

        public GameObject Player { get; private set; }

        [field: SerializeField, Min(0)]
        public float MeleeAttackDistance { get; private set; }

        [field: SerializeField, Min(0), Header("Delay Range")]
        public int MaxNumber { get; private set; }
        
        [field: SerializeField, Min(0)]
        public int MinNumber { get; private set; }

        [field: SerializeField, Min(1), Header("Ranged Attack Options")]

        public int ProjectileAmount { get; private set; }

        [field: SerializeField]
        public GameObject ProjectileObject { get; private set; }

        [field: SerializeField]
        public float InstantiateRadious { get; private set; }

        [field: SerializeField, Min(0)]
        public float BetweenTime { get; private set; }

        [field: SerializeField, Min(0)]
        public float StateLifeTime { get; private set; }

        private void Start()
        {
            Player = GameObject.FindWithTag(playerTag);
            if (Player == null)
            {
                Debug.LogWarning("Player is null, please create gameObject taged `"+playerTag+"` or find player");
                return;
            }
            ChangeState(new CovetIdleState(this));
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, MeleeAttackDistance);
        }
    }
}

