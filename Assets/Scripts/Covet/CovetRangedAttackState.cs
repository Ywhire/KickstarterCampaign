using UnityEngine;

namespace OpenSystemGames.Enemy
{
    public class CovetRangedAttackState : CovetState
    {
        public CovetRangedAttackState(CovetStateMachine stateMachine) : base(stateMachine)
        {}

        private float betweenTimer; 
        public override void Enter()
        {

            if (StateMachine.DebugLogOption)
            {
                Debug.Log("Covet Ranged Attack State");
            }
            StateMachine.Rigidbody2D.velocity = Vector2.zero;
            MakeRangedAttack();

        }

        private void MakeRangedAttack()
        {
            float angle = 360f / StateMachine.ProjectileAmount;
            float rotationOffset = -90f;
            for (int i = 0; i < StateMachine.ProjectileAmount; i++)
            {
                // Instantiates clock-wise
                float x = Mathf.Cos(i * angle * Mathf.Deg2Rad) * StateMachine.InstantiateRadious + StateMachine.transform.position.x;
                float y = Mathf.Sin(i * angle * Mathf.Deg2Rad) * StateMachine.InstantiateRadious + StateMachine.transform.position.y;
                var pObject = GameObject.Instantiate(StateMachine.ProjectileObject, new Vector3(x, y), Quaternion.identity);
                float rotationAngle = i * angle + rotationOffset;
                pObject.transform.Rotate(0, 0, rotationAngle);
            }
        }

        public override void Tick(float deltaTime)
        {
            timer += deltaTime;
            betweenTimer += deltaTime;
            

            // TODO: This will change when animations designed 
            if (timer > StateMachine.StateLifeTime)
            {
                int dice = Random.Range(0, 2);
                if (dice == 0)
                {
                    StateMachine.ChangeState(new CovetIdleState(StateMachine));
                }
                else if (dice == 1)
                {
                    StateMachine.ChangeState(new CovetCooldownState(StateMachine));
                }

                return;
            }

            if (betweenTimer > StateMachine.BetweenTime)
            {
                betweenTimer = 0;
                MakeRangedAttack();
            }
        }

        public override void Exit()
        {

        }

    }
}

