using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public class CovetIdleState : CovetState
    {
        
        public CovetIdleState(CovetStateMachine stateMachine) : base(stateMachine)
        {}
        
        public override void Enter()
        {
            base.Enter();
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Idle State");
            }
            
        }
        public override void Tick(float deltaTime)
        {
            timer += deltaTime;
            bool isPlayerInMeleeRange = IsPlayerInMeleeRange();

            if (isPlayerInMeleeRange)
            {
                StateMachine.ChangeState(new CovetMeleeAttackState(StateMachine));
                return;
            }

            if (timer > changeStateTime)
            {   
                ChangeState(isPlayerInMeleeRange);
                return;
            }

            Movement();
        }
        public override void Exit()
        {
            timer = 0;
        }
        
    }
}

