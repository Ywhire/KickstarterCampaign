using UnityEngine;
namespace OpenSystemGames.Player
{
    public class PlayerTelekinesisState : PlayerState
    {
        private const string movableTag = "Movable";
        public PlayerTelekinesisState(PlayerStateMachine stateMachine) : base(stateMachine)
        { }

        public override void Enter()
        {
            if (stateMachine.debugLogOption)
            {
                Debug.Log("Player Telekinesis State");
            }
        }

        public override void Tick(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit rayHit))
                {
                    rayHit.collider.CompareTag(movableTag);
                    if (stateMachine.debugLogOption)
                    {
                        Debug.Log("I hit the movable object");
                    }
                }
            }
        }
        public override void Exit()
        {

        }



    }
}
