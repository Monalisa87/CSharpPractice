using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousTaskProgramming
{
	class Program
	{
		static void Main(string[] args)
		{
			Thread.CurrentThread.Name = "Main";

			//// Create a task and supply a user delegate by using a lambda expression. 
			//Task taskA = new Task(() => Console.WriteLine("Hello from taskA."));
			//// Start the task.
			//taskA.Start();

			// Define and run the task.
			Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));

			

			// Output a message from the calling thread.
			Console.WriteLine("Hello from thread '{0}'.",
							  Thread.CurrentThread.Name);
			taskA.Wait();
			Console.ReadKey();
		}
	}
}
