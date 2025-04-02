using System.Collections.Generic;

namespace Assets.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        private EnemyController Owner;
        private IState currentState;
        private EnemyState currState;
        public Dictionary<EnemyState, IState> States = new Dictionary<EnemyState, IState>();

        public EnemyStateMachine(EnemyController owner)
        {
            Owner = owner;
            CreateState();
        }

        private void CreateState()
        {
            States.Add(EnemyState.Idle, new IdealState(Owner));
            States.Add(EnemyState.Chase, new ChasingState(Owner));
            States.Add(EnemyState.Attack, new AttackingState(Owner));
        }

        protected void ChangeState(IState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }

        public void Update() => currentState?.Update();

        public EnemyState GetCurrentState() => currState;

        public void ChangeState(EnemyState newState)
        {
            ChangeState(States[newState]);
            currState = newState;  
        }

    }
}