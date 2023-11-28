
using UnityEngine;

namespace OpenSystemGames.Player
{
    public class PlayerAttackState : PlayerState
    {
        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {}
        private float timer;
        private bool isPressable = true;
        public override void Enter()
        {
            if (stateMachine.debugLogOption)
            {
                Debug.Log("Player Attack State");
            }
        }

        public override void Tick(float deltaTime)
        {
            timer += deltaTime;
            if (timer > 3f)
            {
                timer = 0;
                stateMachine.ChangeState(new PlayerIdleState(stateMachine));
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && isPressable)
            {
                var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = 0;
                isPressable = false;
                if (stateMachine.debugLogOption)
                {
                    Debug.Log("Mouse is pressed");
                }
                
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                isPressable = true;
            }
            Movement();
        }

        public override void Exit()
        {
            
        }

        
    }
}

