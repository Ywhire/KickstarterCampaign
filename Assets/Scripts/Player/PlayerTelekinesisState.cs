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
            stateMachine.telekinesisObject.SetActive(true);
            if (stateMachine.debugLogOption)
            {
                Debug.Log("Player Telekinesis State");
            }
        }

        public override void Tick(float deltaTime)
        {

            RaycastHit2D hit = CastRay();

            if (Input.GetKey(KeyCode.Mouse0) && hit.collider != null)
            {
                Vector2 mousePositionXY = GetMousePosition();
                //HOLD OBJECT
                hit.collider.gameObject.transform.position = new Vector3(mousePositionXY.x, mousePositionXY.y, 0);
            }
            if (Input.GetKeyDown(KeyCode.Q)) //CHANGE STATE TO IDLE
            {
                stateMachine.ChangeState(new PlayerIdleState(stateMachine));
            }
        }
        public override void Exit()
        {
            stateMachine.telekinesisObject.SetActive(false);
        }
        private RaycastHit2D CastRay()
        {
            //CAST A RAY FROM "PLAYER" TO "MOUSE POSITION"
            Vector2 mousePosition = GetMousePosition();
            Vector2 targetPosition = mousePosition - new Vector2(stateMachine.transform.position.x, stateMachine.transform.position.y);
            hit = Physics2D.Raycast(stateMachine.transform.position, targetPosition, stateMachine.telekinesisRadius, stateMachine.telekinesisLayer);
            Debug.DrawRay(stateMachine.transform.position, targetPosition, Color.red);

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
