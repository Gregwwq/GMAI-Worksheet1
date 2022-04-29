using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptableStateMachine
{
    public abstract class IStateMachine
    {
        // Accessor to look at the current state.
        public abstract IState CurrentState { get; }

        // List of all possible transitions we can make from this current state.
        public abstract string[] PossibleTransitions();

        // Advance to a named state, returning true on success.
        public abstract bool Advance(string nextState);

        // Is this state a "completion" state.  Are we there yet?
        public abstract bool IsComplete();
    }
}
