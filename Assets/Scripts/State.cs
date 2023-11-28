
namespace OpenSystemGames.Core
{
    public abstract class State
    {
        public abstract void Tick();
        public abstract void Enter();
        public abstract void Exit();

    }
}

