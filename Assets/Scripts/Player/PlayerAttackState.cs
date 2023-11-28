
using UnityEngine;

namespace OpenSystemGames.Player
{
    public class PlayerAttackState : PlayerState
    {
        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {}
        public override void Enter()
        {
            
            GameObject.Instantiate(stateMachine.Projectile, stateMachine.ProjectileSpawnPoint.position, Quaternion.identity);
            if (stateMachine.debugLogOption)
            {
                Debug.Log("Mouse is pressed");
            }
            if (stateMachine.debugLogOption)
            {
                Debug.Log("Player Attack State");
            }
        }

        public override void Tick(float deltaTime)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                stateMachine.ChangeState(new PlayerIdleState(stateMachine));
            }
            Movement();
        }

        public override void Exit()
        {
            
        }

        
    }
}

