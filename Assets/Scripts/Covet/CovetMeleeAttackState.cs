using UnityEngine;

namespace OpenSystemGames.Enemy
{
    public class CovetMeleeAttackState : CovetState
    {
        public CovetMeleeAttackState(CovetStateMachine stateMachine) : base(stateMachine)
        {}

        public override void Enter()
        {

            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Melee Attack State");
            }
            StateMachine.Rigidbody2D.velocity = Vector2.zero;
        }

        public override void Tick(float deltaTime)
        {
            timer += deltaTime;           

            // TODO: this code represents animation time, it will change when animations complete
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

