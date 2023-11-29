using OpenSystemGames.Player;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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
        if (stateMachine.debugLogOption)
        {
            Debug.Log("Player Dash State");
        }
    }
    public override void Tick(float deltaTime)
    {
        if (timer > stateMachine.dashTime)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine));
        }
            
        timer += deltaTime;
        stateMachine.Rigidbody2D.velocity = dashDirection.normalized * stateMachine.DashSpeed;
        
    }
    public override void Exit()
    {
        timer = 0f;
    }

}
