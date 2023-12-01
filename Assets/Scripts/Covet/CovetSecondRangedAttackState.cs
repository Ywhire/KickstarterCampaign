using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public class CovetSecondRangedAttackState : CovetState
    {
        public CovetSecondRangedAttackState(CovetStateMachine stateMachine) : base(stateMachine)
        {}

        public override void Enter()
        {
            base.Enter();
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Second Ranged Attack State");
            }
            StateMachine.Rigidbody2D.velocity = Vector2.zero;
        }
        public override void Tick(float deltaTime)
        {
            // TODO: This will change when animations designed
            timer += deltaTime;
            bool isPlayerInMeleeRange = IsPlayerInMeleeRange();


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
