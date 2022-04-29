using System;
using System.Collections.Generic;

namespace AdaptableStateMachine.FunStateMachine
{
    class FunMachineState : IState
    {
        string mName;
        string mDescription;
        List<FunMachineState> mNeighbors = new List<FunMachineState>();
        public List<FunMachineState> Neighbors { get { return mNeighbors; } }

        /// <summary>
        /// Initializes a new instance of the FunnerState class.
        /// </summary>description
        /// <param name="mName">Name to display for this state</param>
        /// <param name="mDescription">Text to display for this state</param>
        public FunMachineState(string mName, string mDescription)
        {
            this.mName = mName;
            this.mDescription = mDescription;
        }

        #region IState Overrides
        public override string GetName()
        {
            return mName;
        }

        public override void Run()
        {
            // We don't do any fancy stuff, just print out where we are
            Console.WriteLine();
            Console.WriteLine(mDescription);
        }
        #endregion
    }
}
