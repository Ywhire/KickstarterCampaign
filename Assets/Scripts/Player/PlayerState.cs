using OpenSystemGames.Core;
using UnityEngine;

namespace OpenSystemGames.Player
{
    public abstract class PlayerState : State
    {
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerState(PlayerStateMachine stateMachine)
        {
            this.StateMachine = stateMachine;

        }

        public void Movement()
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            StateMachine.Rigidbody2D.velocity = direction.normalized * StateMachine.Speed;
        }
    }
}

