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
            timer += deltaTime;
            if (timer > changeStateTime)
            {
                ChangeState();
                return;
            }
        }

        public override void Exit()
        {
            timer = 0;
        }
    }
}
