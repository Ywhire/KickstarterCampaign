using UnityEngine;

namespace OpenSystemGames.Player
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        

        public override void Enter()
        {
            if (StateMachine.debugLogOption)
            {
                Debug.Log("Player Idle State");
            }
            
        }

        public override void Tick(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StateMachine.ChangeState(new PlayerAttackState(StateMachine));
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StateMachine.ChangeState(new PlayerTelekinesisState(StateMachine));
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StateMachine.ChangeState(new PlayerDashState(StateMachine));
            }
            Movement();
        }
        public override void Exit()
        {
            
        }

        
    }
}

