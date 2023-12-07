using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenSystemGames.Enemy
{
    public class CovetCooldownState : CovetState
    {
        public CovetCooldownState(CovetStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Cooldown State");
            }
        }
        public override void Tick(float deltaTime)
        {
            timer += deltaTime;
            if (timer >= 2f)
            {
                StateMachine.ChangeState(new CovetIdleState(StateMachine));
            }
        }
        public override void Exit()
        {

        }

        
    }
}
