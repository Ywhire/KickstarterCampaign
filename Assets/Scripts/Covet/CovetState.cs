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
        
        public void Movement()
        {
            Vector2 direction = StateMachine.Player.transform.position - StateMachine.transform.position;
           
            StateMachine.Rigidbody2D.velocity = direction.normalized * StateMachine.Speed;
        }
        public void GetAway()
        {
            Vector2 direction = StateMachine.Player.transform.position - StateMachine.transform.position;

            StateMachine.Rigidbody2D.velocity = - direction.normalized * StateMachine.Speed;
        }

        protected bool IsPlayerInMeleeRange()
        {
            return (StateMachine.Player.transform.position - StateMachine.transform.position).magnitude <= 
                StateMachine.MeleeAttackDistance;
        }
        protected void ChangeState(bool IsMeleeRange)
        {
            int no;
            if (IsMeleeRange)
            {
                // This range represents the state size and melee range is excluded
                no = Random.Range(1, 4);
            }
            else
            {
                // This range represents the state size and melee range is included
                no = Random.Range(1, 5);
            }
            
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
                case 4:
                    StateMachine.ChangeState(new CovetMeleeAttackState(StateMachine));
                    break;
                default:
                    StateMachine.ChangeState(new CovetIdleState(StateMachine));
                    break;
            }
        }
    }
}
