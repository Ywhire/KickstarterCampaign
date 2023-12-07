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
            StateMachine.Rigidbody2D.velocity = Vector2.zero;
        }
        public override void Tick(float deltaTime)
        {
            float distance = (StateMachine.Player.transform.position - StateMachine.transform.position).magnitude;
            if (distance > StateMachine.MeleeAttackDistance)
            {
                int dice = Random.Range(0, 6);
                if (dice < 3)
                {
                    StateMachine.ChangeState(new CovetMoveToTargetState(StateMachine));
                }else if (dice >= 3)
                {
                    int dice2 = Random.Range(0, 2);
                    if (dice2 == 0)
                    {
                        StateMachine.ChangeState(new CovetRangedAttackState(StateMachine));
                    }
                    else if (dice2 == 1)
                    {
                        StateMachine.ChangeState(new CovetSecondRangedAttackState(StateMachine));
                    }
                    
                }
            }
            else if (distance <= StateMachine.MeleeAttackDistance)
            {
                int dice = Random.Range(0, 6);
                if (dice < 3)
                {
                    StateMachine.ChangeState(new CovetGetAwayState(StateMachine));
                }
                else if (dice >= 3)
                {
                    int dice2 = Random.Range(0, 2);
                    if (dice2 == 0)
                    {
                        StateMachine.ChangeState(new CovetMeleeAttackState(StateMachine));
                    }
                    else if (dice2 == 1)
                    {
                        StateMachine.ChangeState(new CovetSecondMeleeAttackState(StateMachine));
                    }
                    
                }
            }
        }
        public override void Exit()
        {
        }
        
    }
}

