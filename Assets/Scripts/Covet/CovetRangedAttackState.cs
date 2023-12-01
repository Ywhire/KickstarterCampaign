using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public class CovetRangedAttackState : CovetState
    {
        public CovetRangedAttackState(CovetStateMachine stateMachine) : base(stateMachine)
        {}

        public override void Enter()
        {
            base.Enter();
            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Ranged Attack State");
            }
            StateMachine.Rigidbody2D.velocity = Vector2.zero;

        }
        public override void Tick(float deltaTime)
        {
            float distance = (StateMachine.Player.transform.position - StateMachine.transform.position).sqrMagnitude;
            //if (distance <= StateMachine.MeleeAttackDistance)
            //{
            //    StateMachine.ChangeState(new CovetMeleeAttackState(StateMachine));
            //    return;
            //}

            // TODO: Hello
            timer += deltaTime;
            if (timer > changeStateTime)
            {
                ChangeState();
                return;
            }

        }

        public override void Exit()
        {

        }

    }
}

