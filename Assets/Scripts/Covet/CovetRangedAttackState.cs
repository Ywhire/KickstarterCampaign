using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public class CovetRangedAttackState : CovetState
    {
        public CovetRangedAttackState(CovetStateMachine stateMachine) : base(stateMachine)
        {}

        public override void Enter()
        {
            base.Enter();
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Ranged Attack State");
            }
            StateMachine.Rigidbody2D.velocity = Vector2.zero;

        }
        public override void Tick(float deltaTime)
        {
            timer += deltaTime;
            bool isPlayerInMeleeRange = IsPlayerInMeleeRange();

            // TODO: This will change when animations designed 
            if (timer > changeStateTime)
            {
                if (isPlayerInMeleeRange)
                {
                    StateMachine.ChangeState(new CovetMeleeAttackState(StateMachine));
                    return;
                }
                ChangeState(isPlayerInMeleeRange);
                return;
            }

        }

        public override void Exit()
        {

        }

    }
}

