
using UnityEngine;

namespace OpenSystemGames.Player
{
    public class PlayerAttackState : PlayerState
    {
        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {}
        public override void Enter()
        {
            
            GameObject.Instantiate(StateMachine.Projectile, StateMachine.ProjectileSpawnPoint.position, Quaternion.identity);
            if (StateMachine.debugLogOption)
            {
                Debug.Log("Mouse is pressed");
            }
            if (StateMachine.debugLogOption)
            {
                Debug.Log("Player Attack State");
            }
        }

        public override void Tick(float deltaTime)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                StateMachine.ChangeState(new PlayerIdleState(StateMachine));
            }
            Movement();
        }

        public override void Exit()
        {
            
        }

        
    }
}

