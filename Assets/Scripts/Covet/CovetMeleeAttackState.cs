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
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Melee Attack State");
            }
            StateMachine.Rigidbody2D.velocity = Vector2.zero;
        }

        public override void Tick(float deltaTime)
        {
            float distance = (StateMachine.Player.transform.position - StateMachine.transform.position).sqrMagnitude;
            if (distance <= StateMachine.RangedAttackDistance)
            {
                StateMachine.ChangeState(new CovetRangedAttackState(StateMachine));
                return;
            }
        }

        public override void Exit()
        {

        }
    }
}

