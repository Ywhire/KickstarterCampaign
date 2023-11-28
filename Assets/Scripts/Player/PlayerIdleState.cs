using UnityEngine;

namespace OpenSystemGames.Player
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        

        public override void Enter()
        {
            
        }

        public override void Tick()
        {
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            stateMachine.rb.velocity = direction.normalized;
        }
        public override void Exit()
        {
            
        }
    }
}

