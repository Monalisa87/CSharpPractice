using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
	class Program
	{
		static void Main(string[] args)
		{
			InitializePrinterObject();
			InitializePrinterObject1();
			Console.ReadLine();
		}
		///<summary>  
		/// This method Initializes three Task and run at the same time with very  
		/// less time gap in between. These task initialize Printer object and add document to printer queue  
		///</summary>  
		static void InitializePrinterObject()
		{
			Printer firstPrinterObject = null;
			Printer secondPrinterObject = null;
			Printer thirdPrinterObject = null;
			Task task1 = Task.Factory.StartNew(() => {
				firstPrinterObject = InitializePrinterObjectAndAddDocument("First", "First-Document");
			});
			Task task2 = Task.Factory.StartNew(() => {
				secondPrinterObject = InitializePrinterObjectAndAddDocument("Second", "Second-Document");
			});
			Task task3 = Task.Factory.StartNew(() => {
				thirdPrinterObject = InitializePrinterObjectAndAddDocument("Third", "Third-Document");
			});
			Task.WaitAll(task1, task2, task3);
			Console.WriteLine("All threads complete");
			Console.WriteLine("Are these First Printer Object And Second Printer Object Same - {0} ", firstPrinterObject.Equals(secondPrinterObject) ? "Yes" : "No");
			Console.WriteLine("Are these First Printer Object And Third Printer Object Same - {0} ", firstPrinterObject.Equals(thirdPrinterObject) ? "Yes" : "No");
			Console.WriteLine("Are these Second Printer Object And Third Printer Object Same - {0} ", secondPrinterObject.Equals(thirdPrinterObject) ? "Yes" : "No");
			
		}
		static void InitializePrinterObject1()
		{
			Printer firstPrinterObject = null;
			Printer secondPrinterObject = null;
			Printer thirdPrinterObject = null;
			Task task1 = Task.Factory.StartNew(() => {
				firstPrinterObject = InitializePrinterObjectAndAddDocument1("First_method1", "First-Document_method1");
			});
			Task task2 = Task.Factory.StartNew(() => {
				secondPrinterObject = InitializePrinterObjectAndAddDocument1("Second_method1", "Second-Document_method1");
			});
			Task task3 = Task.Factory.StartNew(() => {
				thirdPrinterObject = InitializePrinterObjectAndAddDocument1("Third_method1", "Third-Document_method1");
			});
			Task.WaitAll(task1, task2, task3);
			Console.WriteLine("All threads complete in second method");
			Console.WriteLine("Are these First_method1 Printer Object And Second_method1 Printer Object Same - {0} ", firstPrinterObject.Equals(secondPrinterObject) ? "Yes" : "No");
			Console.WriteLine("Are these First_method1 Printer Object And Third_method1 Printer Object Same - {0} ", firstPrinterObject.Equals(thirdPrinterObject) ? "Yes" : "No");
			Console.WriteLine("Are these Second_method1 Printer Object And Third_method1 Printer Object Same - {0} ", secondPrinterObject.Equals(thirdPrinterObject) ? "Yes" : "No");
		}
		private static Printer InitializePrinterObjectAndAddDocument(string instanceName, string documentName)
		{
			var printerObject = Printer.GetPrinterInstance(instanceName);
			printerObject.AddDocument(documentName);
			printerObject.PrintDocument();
			return printerObject;
		}
		private static Printer InitializePrinterObjectAndAddDocument1(string instanceName, string documentName)
		{
			var printerObject = Printer.GetPrinterInstance(instanceName);
			printerObject.AddDocument(documentName);
			printerObject.PrintDocument();
			return printerObject;
		}
	}
	///<summary>  
	/// This class is the implementation of singleton design pattern which restricts the instantiation of a class to one object  
	///</summary>  
	public sealed class Printer
	{
		//A static variable which holds a reference to the single created instance  
		private static Printer _printerInstance;
		// A static variable which implements a Queue data structure and holds a documents to be printed  
		private static Queue<String> _queue = new Queue<string>();
		private static object _syncRoot = new object();
		///<summary>  
		/// private and parameterless constructor that prevents other classes from instantiating it  
		///</summary>  
		private Printer() { }
		///<summary>  
		/// This method is to get the instance of Printer class  
		///</summary>  
		///<param name="instanceName">Name of an instance</param>  
		///<returns>An instance of Printer class</returns>  
		public static Printer GetPrinterInstance(string instanceName)
		{
			if (_printerInstance == null)
			{
				//The thread takes out a lock on a shared object, and then checks  
				//whether or not the instance has been created before creating the instance  
				lock (_syncRoot)
				{
					//If there is no instance of printer class exists then instantiate   
					if (_printerInstance == null)
					{
						Console.WriteLine("{0} printer object created", instanceName);
						_printerInstance = new Printer();
					}
				}
			}
			return _printerInstance;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="instanceName"></param>
		public void AddDocument(string instanceName)
		{
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void PrintDocument()
		{

		}
	}
	
}