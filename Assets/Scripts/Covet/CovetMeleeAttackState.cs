using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenSystemGames.Enemy
{
    public class CovetMeleeAttackState : CovetState
    {
        public CovetMeleeAttackState(CovetStateMachine stateMachine) : base(stateMachine)
        {}

        public override void Enter()
        {
            base.Enter();
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
            if (timer > changeStateTime)
            {

                ChangeState(IsPlayerInMeleeRange());
                return;
            }
        }

        public override void Exit()
        {

        }
    }
}

