using UnityEngine;
namespace OpenSystemGames.Player
{
    public class PlayerDashState : PlayerState
    {
        public PlayerDashState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }


        private float timer = 0f;
        private Vector2 dashDirection;

        public override void Enter()
        {
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (StateMachine.debugLogOption)
            {
                Debug.Log("Player Dash State");
            }
        }
        public override void Tick(float deltaTime)
        {
            if (timer > StateMachine.dashTime)
            {
                StateMachine.ChangeState(new PlayerIdleState(StateMachine));
            }

            timer += deltaTime;
            StateMachine.Rigidbody2D.velocity = dashDirection.normalized * StateMachine.DashSpeed;

        }
        public override void Exit()
        {
            timer = 0f;
        }

    }
}

