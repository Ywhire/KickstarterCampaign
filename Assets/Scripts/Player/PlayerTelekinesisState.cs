using UnityEngine;
namespace OpenSystemGames.Player
{
    public class PlayerTelekinesisState : PlayerState
    {
        private const int movableLayer = 6;
        
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
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Mathf.Infinity;
                RaycastHit2D hit = Physics2D.Raycast(mousePos, mousePos - Camera.main.ScreenToViewportPoint(mousePos), Mathf.Infinity);
                if (hit)
                {
                    if (stateMachine.debugLogOption)
                        Debug.Log("I hit");
                }
                
            }
        }
        public override void Exit()
        {

        }



    }
}
