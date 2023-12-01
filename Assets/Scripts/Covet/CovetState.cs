using OpenSystemGames.Core;
using UnityEngine;
namespace OpenSystemGames.Enemy
{
    public abstract class CovetState : State 
    { 
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
    }
}
