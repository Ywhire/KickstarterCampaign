using OpenSystemGames.Core;
using UnityEngine;

namespace OpenSystemGames.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerStateMachine : StateMachine
    {
        public bool debugLogOption;

        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField]
        public Animator Animator { get; private set; }
        [field: SerializeField]
        public GameObject LeftHand { get; private set; }
        [field: SerializeField]
        public GameObject RightHand { get; private set; }
        private void Start()
        {
            ChangeState(new PlayerIdleState(this));
        }
    }
}
