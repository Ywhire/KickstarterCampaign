using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenSystemGames.Enemy
{
    public class CovetSecondMeleeAttackState : CovetState
    {
        public CovetSecondMeleeAttackState(CovetStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Second Melee Attack State");
            }
        }
        public override void Tick(float deltaTime)
        {
            timer += deltaTime;
            if (timer >= 2f)
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

