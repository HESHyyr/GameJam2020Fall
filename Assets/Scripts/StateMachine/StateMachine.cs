using System;
using System.Collections.Generic;

namespace SpookuleleGames.StateMachine
{
    public class StateMachine
    {
        private IState _currentState;
        private Dictionary<IState, List<Transition>> _transitions = new Dictionary<IState, List<Transition>>();
        private List<Transition> _currentTransitions = new List<Transition>();
        private List<Transition> _anyTransitions = new List<Transition>();
        private static List<Transition> EMPTY_TRANSITIONS = new List<Transition>(capacity: 0);

        public IState CurrentState => _currentState;

        public void Tick()
        {
            Transition transition = GetTransition();
            if (transition != null)
            {
                SetState(transition.To);
            }

            _currentState?.Tick();
        }

        public void SetState(IState state)
        {
            if (state == _currentState) { return; } //If trying to set state to current state, end

            IState previousState = _currentState;

            _currentState?.OnExit(state); //Exit current state
            _currentState = state; //Set current state to new state

            _transitions.TryGetValue(_currentState, out _currentTransitions); //Try to obtain transitions
            if (_currentTransitions == null)
            {
                _currentTransitions = EMPTY_TRANSITIONS; //Set to empty if none found
            }

            _currentState.OnEnter(previousState); //Enter new state
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if (_transitions.TryGetValue(from, out List<Transition> transitions) == false)
            {
                transitions = new List<Transition>();
                _transitions[from] = transitions;
            }

            transitions.Add(new Transition(to, predicate));
        }

        public void AddAnyTransition(IState state, Func<bool> predicate)
        {
            _anyTransitions.Add(new Transition(state, predicate));
        }

        private class Transition
        {
            public Func<bool> Condition { get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }
        }

        private Transition GetTransition()
        {
            foreach (Transition transition in _anyTransitions)
            {
                if (transition.Condition())
                {
                    return transition;
                }
            }

            foreach (Transition transition in _currentTransitions)
            {
                if (transition.Condition())
                {
                    return transition;
                }
            }

            return null;
        }
    }
}