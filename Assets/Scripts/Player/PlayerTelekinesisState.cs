using UnityEngine;
namespace OpenSystemGames.Player
{
    public class PlayerTelekinesisState : PlayerState
    {
        private Vector2 stablePoint;
        private Vector2 hitPosXY;
        private Vector2 mousePos;
        RaycastHit2D hit;


        public PlayerTelekinesisState(PlayerStateMachine stateMachine) : base(stateMachine)
        { }

        public override void Enter()
        {
            stablePoint = StateMachine.transform.position;
            StateMachine.telekinesisObject.SetActive(true);
            if (StateMachine.debugLogOption)
            {
                Debug.Log("Player Telekinesis State");
            }
        }

        public override void Tick(float deltaTime)
        {
            StateMachine.transform.position = stablePoint;
            RaycastHit2D hit = CastRay();
            mousePos = GetMousePosition();
            if (hit.collider != null)
            {
                hitPosXY = new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y);
            }
            if (Input.GetKey(KeyCode.Mouse0) && hit.collider != null && ((hitPosXY - mousePos).magnitude <= 0.75f))
            {
                //HOLD OBJECT
                hit.collider.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            }
            if (Input.GetKeyDown(KeyCode.Q)) //CHANGE STATE TO IDLE
            {
                StateMachine.ChangeState(new PlayerIdleState(StateMachine));
            }
        }
        public override void Exit()
        {
            StateMachine.telekinesisObject.SetActive(false);
        }
        private RaycastHit2D CastRay()
        {
            //CAST A RAY FROM "PLAYER" TO "MOUSE POSITION"
            Vector2 mousePosition = GetMousePosition();
            Vector2 targetPosition = mousePosition - new Vector2(StateMachine.transform.position.x, StateMachine.transform.position.y);
            hit = Physics2D.Raycast(StateMachine.transform.position, targetPosition, StateMachine.telekinesisRadius , StateMachine.telekinesisLayer);
            Debug.DrawRay(StateMachine.transform.position, targetPosition, Color.red);

            return hit;
            
        }
        private Vector2 GetMousePosition()
        {
            Vector3 mouseWorldPosition = StateMachine.cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosXY = new Vector2(mouseWorldPosition.x,mouseWorldPosition.y);
            return mousePosXY;
        }



    }
}
