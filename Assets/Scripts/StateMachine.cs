using UnityEngine;

namespace OpenSystemGames.Core
{
    public class StateMachine : MonoBehaviour
    {
        private State currentState;

        private void Update()
        {
            currentState?.Tick(Time.deltaTime);
        }

        public void ChangeState(State newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }
    }
}
