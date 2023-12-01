using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public class CovetIdleState : CovetState
    {
        
        public CovetIdleState(CovetStateMachine stateMachine) : base(stateMachine)
        {}

        public override void Enter()
        {
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Idle State");
            }
        }
        public override void Tick(float deltaTime)
        {
            float distance = (StateMachine.Player.transform.position - StateMachine.transform.position).sqrMagnitude;
            if (distance <= StateMachine.RangedAttackDistance)
            {
                StateMachine.ChangeState(new CovetRangedAttackState(StateMachine));
                return;
            }
            //if (distance <= StateMachine.MeleeAttackDistance)
            //{
            //    StateMachine.ChangeState(new CovetMeleeAttackState(StateMachine));
            //    return;
            //}
            Movement();
            
        }
        public override void Exit()
        {
            
        }
  
    }
}

