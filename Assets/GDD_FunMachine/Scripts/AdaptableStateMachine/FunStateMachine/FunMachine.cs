using System.Collections.Generic;

namespace AdaptableStateMachine.FunStateMachine
{
    // If you are paying attention, you'll notice that the actual state machine content is tiny.
    // Most of the work and effort in this class is hooking up data. The actual state machine 
    // manipulation is quite easy.

    // In fact, that effort is best done outside the program.  That's where the next lesson will apply.
    class FunMachine : IStateMachine
    {
        List<FunMachineState> mStates;
        FunMachineState mCurrent;
        FunMachineState mExit;

        /// <summary>
        /// Initializes a new instance of the FunnerMachine class.
        /// </summary>
        public FunMachine()
        {
            // Create all the fun states in our mini-world
            FunMachineState entryHall = new FunMachineState("Grand Entrance", "You are standing in a grand entrance of a castle.\nThere are tables and chairs, but nothing you can interact with.");
            FunMachineState staircase = new FunMachineState("Grand Staircase", "The staircase is made from beautiful granite.");
            FunMachineState eastWing = new FunMachineState("East Wing", "This wing is devoted to bedrooms.");
            FunMachineState westWing = new FunMachineState("West Wing", "This wing is devoted to business.");
            FunMachineState bedroomA = new FunMachineState("Master Suite", "This is the master suite.  What a fancy room.");
            FunMachineState bedroomB = new FunMachineState("Prince Bob's Room", "The prince has an extensive library on his wall.\nHe also has more clothes than most males know what to do with.");
            FunMachineState bedroomC = new FunMachineState("Princess Alice's Room", "The princess has filled her room with a small compur lab.\nShe spends her days playing games and writing code.");
            FunMachineState workroomA = new FunMachineState("Study", "This is the study.  It has many books.");
            FunMachineState workroomB = new FunMachineState("Bathroom", "Every home needs one");
            FunMachineState workroomC = new FunMachineState("Do Not Enter", "I warned you not to enter.\nYou are in a maze of twisty little passages, all alike.");
            FunMachineState passage = new FunMachineState("Twisty Passage", "You are in a maze of twisty little passages, all alike");

            // Special case.
            mExit = new FunMachineState("Outside", "You have successfully exited the castle.");

            // Hook up doors.
            entryHall.Neighbors.Add(staircase);
            entryHall.Neighbors.Add(mExit);

            staircase.Neighbors.Add(eastWing);
            staircase.Neighbors.Add(westWing);
            staircase.Neighbors.Add(entryHall);

            eastWing.Neighbors.Add(bedroomA);
            eastWing.Neighbors.Add(bedroomB);
            eastWing.Neighbors.Add(bedroomC);
            eastWing.Neighbors.Add(staircase);

            bedroomA.Neighbors.Add(eastWing);
            bedroomB.Neighbors.Add(eastWing);
            bedroomC.Neighbors.Add(eastWing);

            westWing.Neighbors.Add(workroomA);
            westWing.Neighbors.Add(workroomB);
            westWing.Neighbors.Add(workroomC);

            workroomA.Neighbors.Add(westWing);
            workroomB.Neighbors.Add(westWing);

            // Trap of doom.
            workroomC.Neighbors.Add(passage);
            passage.Neighbors.Add(passage);

            // Add them to the collection
            mStates = new List<FunMachineState>();
            mStates.Add(entryHall);
            mStates.Add(staircase);
            mStates.Add(eastWing);
            mStates.Add(westWing);
            mStates.Add(bedroomA);
            mStates.Add(bedroomB);
            mStates.Add(bedroomC);
            mStates.Add(workroomA);
            mStates.Add(workroomB);
            mStates.Add(workroomC);
            mStates.Add(passage);
            mStates.Add(mExit);

            // Finally set my starting point
            mCurrent = entryHall;
        }

        #region IStateMachine Overrides
        public override IState CurrentState
        {
            get { return mCurrent; }
        }
        public override string[] PossibleTransitions()
        {
            List<string> result = new List<string>();
            foreach (FunMachineState state in mCurrent.Neighbors)
            {
                result.Add(state.GetName());
            }
            return result.ToArray();
        }
        public override bool Advance(string nextState)
        {
            foreach (FunMachineState state in mCurrent.Neighbors)
            {
                if (nextState == state.GetName())
                {
                    mCurrent = state;
                    return true;
                }
            }
            System.Console.WriteLine("Invalid state.");
            return false;
        }
        public override bool IsComplete()
        {
            return mCurrent == mExit;
        }
        #endregion
    }
}
