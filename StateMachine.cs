using System;
using Godot;

namespace StateMachineDemo
{
    public interface IStateMachine
    {
    }

    public sealed class StateMachine<T> : IStateMachine where T : struct, IComparable, IConvertible, IFormattable
    {
        public Node Target;

        public StateMachine(Node target)
        {
            Target = target;
        }

        public T CurrentState { get; set; }
        public T PreviousState { get; set; }


        public void ChangeState(T newState)
        {
            if (!newState.Equals(CurrentState))
            {
                PreviousState = CurrentState;
                CurrentState = newState;
            }
        }

        public void RestorePreviousState()
        {
            CurrentState = PreviousState;
        }
    }
}