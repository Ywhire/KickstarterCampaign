using OpenSystemGames.Core;
using OpenSystemGames.Player;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field:SerializeField]
    public float speed { get; private set; }

    [field: SerializeField]
    public Rigidbody2D rb { get; private set; }
    private void Start()
    {
        ChangeState(new PlayerIdleState(this));
    }
}
