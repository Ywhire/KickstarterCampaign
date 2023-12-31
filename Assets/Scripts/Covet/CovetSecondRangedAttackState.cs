using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public class CovetSecondRangedAttackState : CovetState
    {
        public CovetSecondRangedAttackState(CovetStateMachine stateMachine) : base(stateMachine)
        {}

        public override void Enter()
        {

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



            if (timer > 2f)
            {
                int dice = Random.Range(0, 2);
                if (dice == 0)
                {
                    StateMachine.ChangeState(new CovetIdleState(StateMachine));
                }
                else if (dice == 1)
                {
                    StateMachine.ChangeState(new CovetCooldownState(StateMachine));
                }

                return;
            }
        }

        public override void Exit()
        {

        }
    }
}
