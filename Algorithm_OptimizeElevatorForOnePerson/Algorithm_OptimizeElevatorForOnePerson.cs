using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm_OptimizeElevatorForOnePerson
{
    // Idea: simulation
    // In this simulation, I am assuming if an elevator goes to the next floor it takes 1 unit of time.
    // If there is a stop situation it takes 2 units of time
    // The elevator class contains a method Next(), this would run to next time increment. 
    // If it reaches a stop, it will wait, and if it is going it will change position by 1 floor
    // GetBestElevator() would run this simulation
    // it will call Next() for all elevators
    // during the process, it will cache the state for each elevator. 
    // If at a particular time slot it picked up, then the state changes from Going to PickedUp
    // and when we reached the destination from the Pickedup state, we will break out of the loop. 

    // Big O: Time = O(T) where T = numberOfFloors * (elevator speed + elevator open and close door time) * number of elevators (K * F * N)
    //        Space = O(N) where N = number of elevators

    [TestClass]
    public class Algorithm_OptimizeElevatorForOnePersonUnitTests
    {
        [TestMethod]
        public void GivenOneEmptyElevatorAndRequest_GetBestElevator_ShouldReturnCorrectIndex()
        {
            var elevators = new Elevator[] { new Elevator { Position = 0, Stops = new Queue<int>(), Time = 0 } };

            var elevatorIndex = GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 0);
        }

        [TestMethod]
        public void GivenTwoEmptyElevatorsAtTheSamePositionAndRequest_GetBestElevator_ShouldReturnFirstIndex()
        {
            var elevators = new Elevator[] { new Elevator { Position = 0, Stops = new Queue<int>(), Time = 0 }, new Elevator { Position = 0, Stops = new Queue<int>(), Time = 0 } };

            var elevatorIndex = GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 0);
        }

        [TestMethod]
        public void GivenTwoElevatorsWithTheSecondCloserToUser_GetBestElevator_ShouldReturnSecondIndex()
        {
            var elevators = new Elevator[] { new Elevator { Position = 0, Stops = new Queue<int>(), Time = 0 }, new Elevator { Position = 5, Stops = new Queue<int>(), Time = 0 } };

            var elevatorIndex = GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 1);
        }

        [TestMethod]
        public void GivenTwoElevatorsWithOneCloserToUserButHaveQueuesLonger_GetBestElevator_ShouldReturnSecondIndex()
        {
            var elevator1Queue = new Queue<int>();
            elevator1Queue.Enqueue(0);
            var elevators = new Elevator[] { new Elevator { Position = 10, Stops = elevator1Queue, Time = 0 }, new Elevator { Position = 5, Stops = new Queue<int>(), Time = 0 } };

            var elevatorIndex = GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 1);
        }

        [TestMethod]
        public void GivenThreeElevatorsDifferentQueues_GetBestElevator_ShouldReturnTheCorrectIndexIndex()
        {
            var elevator1Queue = new Queue<int>();
            elevator1Queue.Enqueue(0); elevator1Queue.Enqueue(2); elevator1Queue.Enqueue(12);
            var elevator2Queue = new Queue<int>();
            elevator2Queue.Enqueue(10); elevator2Queue.Enqueue(0); elevator2Queue.Enqueue(5);
            var elevator3Queue = new Queue<int>();
            elevator3Queue.Enqueue(12); elevator3Queue.Enqueue(14);
            var elevators = new Elevator[] { new Elevator { Position = 10, Stops = elevator1Queue }, new Elevator { Position = 5, Stops = elevator2Queue }, new Elevator { Position = 11, Stops = elevator3Queue } };

            var elevatorIndex = GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 2);
        }

        [TestMethod]
        public void GivenElevatorsWithNoStops_Next_ShouldNotChangePosition()
        {
            var elevator = new Elevator { Position = 0, Stops = new Queue<int>() };

            elevator.Next();

            Assert.IsTrue(elevator.Position == 0);
        }

        [TestMethod]
        public void GivenElevatorsWithNoStops_Next_ShouldNotChangeTime()
        {
            var elevator = new Elevator { Position = 0, Stops = new Queue<int>() };

            elevator.Next();

            Assert.IsTrue(elevator.Time == 0);
        }

        [TestMethod]
        public void GivenElevatorsWithPositionAndStop_Next_ShouldReachFinalStop()
        {
            var elevatorQueue = new Queue<int>();
            elevatorQueue.Enqueue(2);
            var elevator = new Elevator { Position = 0, Stops = elevatorQueue };

            elevator.Next(); elevator.Next();

            Assert.IsTrue(elevator.Position == 2);
        }

        [TestMethod]
        public void GivenElevatorsAndQueuedPositions_Next_ShouldReachWithCorrectTime()
        {
            var elevatorQueue = new Queue<int>();
            elevatorQueue.Enqueue(2);
            var elevator = new Elevator { Position = 0, Stops = elevatorQueue };

            elevator.Next(); elevator.Next(); elevator.Next(); elevator.Next();

            Assert.IsTrue(elevator.Time == 4);
        }

        public int GetBestElevator(Elevator[] elevators, int position, int destination)
        {
            var simulationStates = new ElevatorSimulationState[elevators.Length];

            while (true)
            {
                for(int i = 0; i < elevators.Length; i++)
                {
                    if (elevators[i].Stops.Count == 0)
                    {
                        if (simulationStates[i] == ElevatorSimulationState.Going)
                        {
                            elevators[i].Stops.Enqueue(position);
                        }
                 
                        elevators[i].Stops.Enqueue(destination);
                    }

                    if (simulationStates[i] == ElevatorSimulationState.Going && elevators[i].Position == position)
                    {
                        simulationStates[i] = ElevatorSimulationState.PickedUp;
                    }

                    if (simulationStates[i] == ElevatorSimulationState.PickedUp && elevators[i].Position == destination)
                    {
                        simulationStates[i] = ElevatorSimulationState.Done;
                    }

                    if (simulationStates[i] == ElevatorSimulationState.Done)
                    {
                        return i;
                    }

                    elevators[i].Next();
                }
            }
        }

        public class Constants
        {
            public const int ElevatorSpeed = 1;
            public const int ElevatorStopWaitTimePerTurn = 1;
            public const int StopAndGoWaitTurns = 2;
        }

        public enum ElevatorSimulationState
        {
            Going = 0,
            PickedUp,
            Done
        }

        public class Elevator
        {
            private int _stopCounter = 0;

            public int Time { get; set; } = 0;
            public int Position { get; set; }
            public Queue<int> Stops { get; set; }

            public void Next()
            {
                if (Stops.Count == 0)
                {
                    return;
                }

                if (Position == Stops.Peek())
                {
                    _stopCounter++;
                    Time += Constants.ElevatorStopWaitTimePerTurn;

                    if (_stopCounter == Constants.StopAndGoWaitTurns)
                    {
                        _stopCounter = 0;
                        Stops.Dequeue();
                    }
                }
                else
                {
                    Time += Constants.ElevatorSpeed;
                    Position = Position > Stops.Peek() ? Position - 1 : Position + 1;
                }
            }
        }
    }
}
