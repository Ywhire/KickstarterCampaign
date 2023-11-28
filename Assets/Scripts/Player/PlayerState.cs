using OpenSystemGames.Core;

namespace OpenSystemGames.Player
{
    public abstract class PlayerState : State
    {
        public PlayerStateMachine stateMachine { get; private set; }
        public PlayerState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;

        }
    }
}

