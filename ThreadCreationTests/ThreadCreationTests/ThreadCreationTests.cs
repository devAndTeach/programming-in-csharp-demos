using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThreadCreationTests
{
    [TestClass]
    public class ThreadCreationTests
    {
        [TestMethod]
        public void ShouldCreateTaskUsingActionDelegate()
        {
            Task task1 = new Task(new Action(GetTheTime));
            Assert.IsNotNull(task1);           
        }



        [TestMethod]
        public void ShouldCreateTaskUsingAnonymousDelegate()
        {
            Task task2 =
                new Task(
                    delegate 
                    {
                        Console.WriteLine(
                             "The time now is {0}", DateTime.Now);
                    });
            Assert.IsNotNull(task2);
        }

        [TestMethod]
        public void ShouldCreateTaskUsingLambdaToCallNamedMethod()
        {
            Task task1 = new Task(() => GetTheTime());
            Assert.IsNotNull(task1);
        }






        [TestMethod]
        public void ShouldCreateTaskFromLambdaExpression()
        {
            Task task2 =
                new Task(
                    delegate
                    {
                        Console.WriteLine(
                             "The time now is {0}", DateTime.Now);
                    });

            Task task1 = new Task(() => GetTheTime());
            // This is equivalent to: Task task1 = new Task( delegate(MyMethod) );
            Assert.IsNotNull(task2);
        }


        [TestMethod]
        public void ShouldCreateAndScheduleThreeTasks()
        {
            var task1 = new Task(() => Console.WriteLine("Task 1 has completed."));
            task1.Start();

            var task3 = Task.Factory.StartNew(() => Console.WriteLine("Task 3 has completed."));
            var task4 = Task.Run(() => Console.WriteLine("Task 4 has completed. "));

            Assert.IsNotNull(task1);
            Assert.IsNotNull(task3);
            Assert.IsNotNull(task4);
        }


        [TestMethod]
        public void ShouldExecuteTaskThatReturnsDayOfWeek()
        {
            // Create and queue a task that returns the day of the week as a string.
            Task<DayOfWeek> task1 = 
                Task.Run<DayOfWeek>(
                    () => DateTime.Now.DayOfWeek);
            // Retrieve and display the task result.
            Console.WriteLine(task1.Result);
            Assert.IsTrue( task1.Result == DayOfWeek.Wednesday);
        }



        [TestMethod]
        public void ShouldExecuteSequentialAndParallelTasks()
        {

          
            var capacity = 600000;
            int from = 0;
            int to = 500000;
            double[] array = new double[capacity];
            // This is a sequential implementation:
            var sequentialWatch = new System.Diagnostics.Stopwatch();

            sequentialWatch.Start();

            for (int index = 0; index < 500000; index++)
            {
                array[index] = Math.Sqrt(index);
                Console.WriteLine($"index: {index} - value: {array[index]}");

            }
            sequentialWatch.Stop();
            long sequentialElapsedTime = sequentialWatch.ElapsedMilliseconds;
            Console.WriteLine($"==========SIMULATE PARALLEL OPERATION =============");
            var parallelWatch = new System.Diagnostics.Stopwatch();
            parallelWatch.Start();
            // This is the equivalent parallel implementation:
            Parallel.For(from, to, index =>
            {
                array[index] = Math.Sqrt(index);
                Console.WriteLine($"index: {index} - value: {array[index]}");
            });

            parallelWatch.Stop();
            long parallelElapsedTime = parallelWatch.ElapsedMilliseconds;
            Assert.IsTrue(sequentialElapsedTime > parallelElapsedTime);
        }




        [TestMethod]
        public void ShouldCreate()
        {
            Task task1 = new Task(new Action(GetTheTime));
            Assert.IsNotNull(task1);
        }

        private static void GetTheTime()
        {
            Console.WriteLine("The time now is {0}", DateTime.Now);
        }
    }
}
