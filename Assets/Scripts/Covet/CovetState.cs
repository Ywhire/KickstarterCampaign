using OpenSystemGames.Core;
using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public abstract class CovetState : State 
    {
        protected int changeStateTime;
        protected float timer;
        public CovetStateMachine StateMachine { get; private set; }
        public CovetState(CovetStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        public override void Enter()
        {
            changeStateTime = Random.Range(StateMachine.MinNumber, StateMachine.MaxNumber);
        }
        public void Movement()
        {
            Vector2 direction = StateMachine.Player.transform.position - StateMachine.transform.position;
           
            StateMachine.Rigidbody2D.velocity = direction.normalized * StateMachine.Speed;
        }

        protected void ChangeState()
        {
            // This range represents the state size
            int no = Random.Range(1, 4);
            switch (no)
            {
                case 1:
                    StateMachine.ChangeState(new CovetIdleState(StateMachine));
                    break;
                case 2:
                    StateMachine.ChangeState(new CovetRangedAttackState(StateMachine));
                    break;
                case 3:
                    StateMachine.ChangeState(new CovetSecondRangedAttackState(StateMachine));
                    break;
                default:
                    StateMachine.ChangeState(new CovetIdleState(StateMachine));
                    break;
            }
        }
    }
}
