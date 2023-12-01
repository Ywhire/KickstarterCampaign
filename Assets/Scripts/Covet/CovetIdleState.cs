using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public class CovetIdleState : CovetState
    {
        
        public CovetIdleState(CovetStateMachine stateMachine) : base(stateMachine)
        {}
        
        public override void Enter()
        {
            base.Enter();
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Idle State");
            }
            
        }
        public override void Tick(float deltaTime)
        {
            float distance = (StateMachine.Player.transform.position - StateMachine.transform.position).sqrMagnitude;
            timer += deltaTime;
            if (timer > changeStateTime)
            {
                ChangeState();
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
            timer = 0;
        }
        
    }
}

