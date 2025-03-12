using Assets.Scripts.Events;
using System.Collections.Generic;

namespace Assets.Scripts.Enemy
{
    public class EnemyStateMachine
    {
        private EnemyController Owner;
        private IState currentState;
        private EnemyState currState;
        public Dictionary<EnemyState, IState> States = new Dictionary<EnemyState, IState>();
        private EventService eventService;

        public EnemyStateMachine(EnemyController owner, EventService eventService)
        {
            Owner = owner;
            this.eventService = eventService;
            CreateState();
        }

        private void CreateState()
        {
            States.Add(EnemyState.Idle, new IdealState(Owner));
            States.Add(EnemyState.Chase, new ChasingState(Owner));
            States.Add(EnemyState.Attack, new AttackingState(Owner,eventService));
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