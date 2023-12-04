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
            base.Enter();
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
            bool isPlayerInMeleeRange = IsPlayerInMeleeRange();
            

            // TODO: This will change when animations designed 
            if (timer > StateMachine.StateLifeTime)
            {
                if (isPlayerInMeleeRange)
                {
                    StateMachine.ChangeState(new CovetMeleeAttackState(StateMachine));
                    return;
                }
                ChangeState(isPlayerInMeleeRange);
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

