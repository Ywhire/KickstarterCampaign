using UnityEngine;
namespace OpenSystemGames.Player
{
    public class PlayerTelekinesisState : PlayerState
    {
        private const int movableLayer = 6;
        RaycastHit2D hit;


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

            RaycastHit2D hit = CastRay();

            if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null)
            {
                //HOLD OBJECT
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null)
            {
                //RELEASE OBJECT
            }
            if (Input.GetKeyDown(KeyCode.Q)) //CHANGE STATE TO IDLE
            {
                stateMachine.ChangeState(new PlayerIdleState(stateMachine));
            }
        }
        public override void Exit()
        {

        }
        private RaycastHit2D CastRay()
        {
            //CAST A RAY FROM "PLAYER" TO ANY COLLIDEABLE "OBJECT"
            Vector2 mousePosition = GetMousePosition();
            hit = Physics2D.Raycast(stateMachine.transform.position, mousePosition, stateMachine.telekinesisLayer, stateMachine.telekinesisRadius);
            Debug.DrawRay(stateMachine.transform.position, mousePosition, Color.red);
            Debug.Log(hit.collider);
            return hit;
            
        }
        private Vector2 GetMousePosition()
        {
            Vector3 mouseWorldPosition = stateMachine.cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosXY = new Vector2(mouseWorldPosition.x,mouseWorldPosition.y);
            return mousePosXY;
        }



    }
}
