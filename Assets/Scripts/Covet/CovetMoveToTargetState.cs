using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenSystemGames.Enemy
{
    public class CovetMoveToTargetState : CovetState
    {
        public CovetMoveToTargetState(CovetStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Move to Target State");
            }
        }

        public override void Tick(float deltaTime)
        {
            timer += deltaTime;
            Movement();
            float distance = (StateMachine.Player.transform.position - StateMachine.transform.position).magnitude;
            if (timer >= 3f || distance <= StateMachine.MeleeAttackDistance)
            {
                StateMachine.ChangeState(new CovetIdleState(StateMachine));
            }
        }

        public override void Exit()
        {

        }
    }
}
