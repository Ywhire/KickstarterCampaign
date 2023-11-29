using OpenSystemGames.Core;
using UnityEngine;

namespace OpenSystemGames.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerStateMachine : StateMachine
    {
        public bool debugLogOption;
        public Transform ProjectileSpawnPoint;

        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public Rigidbody2D Rigidbody2D { get; private set; }

        [field: SerializeField]
        public Animator Animator { get; private set; }

        [field: SerializeField]
        public GameObject Projectile { get; private set; }

        [field: SerializeField, Header("Dash Paramters")]
        public float DashSpeed { get; private set; }

        [field: SerializeField]
        public float dashTime { get; private set; }

        private void Start()
        {
            ChangeState(new PlayerIdleState(this));
        }
    }
}
