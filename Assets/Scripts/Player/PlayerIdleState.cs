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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                stateMachine.ChangeState(new PlayerAttackState(stateMachine));
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stateMachine.ChangeState(new PlayerTelekinesisState(stateMachine));
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                stateMachine.ChangeState(new PlayerDashState(stateMachine));
            }
            Movement();
        }
        public override void Exit()
        {
            
        }

        
    }
}

