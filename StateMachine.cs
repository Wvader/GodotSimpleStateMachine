using System;
using Godot;

namespace Bigmonte.Tools
{
    public interface IStateMachine { }
    
    public class StateMachine<T> : IStateMachine where T : struct, IComparable, IConvertible, IFormattable
    {
        public Node Target;
        
        public StateMachine(Node target)
        {
            Target = target;
        }

        public T CurrentState { get; set; }
        public T PreviousState { get; set; }
        

        public virtual void ChangeState(T newState)
        {
            if (!newState.Equals(CurrentState))
            {
                PreviousState = CurrentState;
                CurrentState = newState;
            }
        }

        public virtual void RestorePreviousState()
        {
            CurrentState = PreviousState;
        }
    }
}