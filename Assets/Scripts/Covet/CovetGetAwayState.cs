
using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public class CovetGetAwayState : CovetState
    {
        public CovetGetAwayState(CovetStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Get Away State");
            }
        }
        public override void Tick(float deltaTime)
        {
            timer += deltaTime;
            GetAway();
            if (timer >= 3f)
            {
                StateMachine.ChangeState(new CovetIdleState(StateMachine));
            }
        }
        public override void Exit()
        {
            
        }

        
    }
}

