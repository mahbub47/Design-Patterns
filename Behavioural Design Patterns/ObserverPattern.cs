using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Behavioural_Design_Patterns
{
    public class ObserverPattern
    {
        public interface IFitnessDataObserver
        {
            void Update(FitnessData data);
        }

        public interface IFitnessDataSubject
        {
            void ReigisterSubscriber(IFitnessDataObserver observer);
            void UnsubscribesSubscriber(IFitnessDataObserver observer);
            void NotifySubscribers();
        }

        public class FitnessData : IFitnessDataSubject
        {
            private int steps;
            private int activeMunites;
            private int callories;
            List<IFitnessDataObserver> observerList = new();

            public void NotifySubscribers()
            {
                foreach (var observer in observerList)
                {
                    observer.Update(this);
                }
            }

            public void ReigisterSubscriber(IFitnessDataObserver observer)
            {
                observerList.Add(observer);
            }

            public void UnsubscribesSubscriber(IFitnessDataObserver observer)
            {
                observerList.Remove(observer);
            }

            public void NewFitnessDataPushed(int  steps,  int activeMunites, int callories)
            {
                this.steps = steps;
                this.activeMunites = activeMunites;
                this.callories = callories;

                Console.WriteLine($"New fitness data recieved: Steps: {steps}, Active Munites: {activeMunites}, Callories: {callories}");

                NotifySubscribers();
            }

            public void DailyReset()
            {
                steps = 0;
                activeMunites = 0;
                callories = 0;

                Console.WriteLine("Daily reset performed!");
                NotifySubscribers();
            }

            public int GetCurrentSteps()
            {
                return steps; 
            }

            public int GetCallories()
            {
                return callories;
            }

            public int GetActiveMunites()
            {
                return activeMunites;
            }
        }

        public class LiveActivityDisplay : IFitnessDataObserver
        {
            public void Update(FitnessData data)
            {
                Console.WriteLine($"Live Activity: Total Steps: {data.GetCurrentSteps()}, Total Callories: {data.GetCallories()}, Active Time: {data.GetActiveMunites()}");
            }
        }

        public class ProgressLogger : IFitnessDataObserver
        {
            public void Update(FitnessData data)
            {
                Console.WriteLine($"Logger Saving to DB: Total Steps: {data.GetCurrentSteps()}, Total Callories: {data.GetCallories()}, Active Time: {data.GetActiveMunites()}");
            }
        }

        public class GoalNotifier : IFitnessDataObserver
        {
            private int goalSteps = 1000;
            private bool isGoalachieved = false;
            public void Update(FitnessData data)
            {
                if(data.GetCurrentSteps() >= goalSteps && !isGoalachieved)
                {
                    Console.WriteLine($"You have reached your goal!, with {data.GetCurrentSteps()} steps");
                    isGoalachieved = true;
                }
            }

            public void Reset()
            {
                isGoalachieved = false;
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                FitnessData fitnessData = new FitnessData();

                LiveActivityDisplay liveActivity = new LiveActivityDisplay();
                ProgressLogger progressLogger = new ProgressLogger();
                GoalNotifier goalNotifier = new GoalNotifier();

                fitnessData.ReigisterSubscriber(liveActivity);
                fitnessData.ReigisterSubscriber(progressLogger);
                fitnessData.ReigisterSubscriber(goalNotifier);

                fitnessData.NewFitnessDataPushed(200, 20, 40);
                fitnessData.NewFitnessDataPushed(500, 10, 50);
                fitnessData.NewFitnessDataPushed(1100, 5, 10);

                goalNotifier.Reset();
                fitnessData.DailyReset();
            }
        }
    }
}
