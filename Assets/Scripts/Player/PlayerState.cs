using OpenSystemGames.Core;
using UnityEngine;

namespace OpenSystemGames.Player
{
    public abstract class PlayerState : State
    {
        public PlayerStateMachine stateMachine { get; private set; }
        public PlayerState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;

        }

        public void Movement()
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            stateMachine.Rigidbody2D.velocity = direction.normalized * stateMachine.Speed;
        }
    }
}

