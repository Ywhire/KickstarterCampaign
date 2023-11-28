using UnityEngine;

namespace OpenSystemGames.Player
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        

        public override void Enter()
        {
            if (stateMachine.debugLogOption)
            {
                Debug.Log("Player Idle State");
            }
            
        }

        public override void Tick(float deltaTime)
        {
            if (Input.GetAxis("Fire1") == 1)
            {
                stateMachine.ChangeState(new PlayerAttackState(stateMachine));
            }
            Movement();
        }
        public override void Exit()
        {
            
        }

        
    }
}

