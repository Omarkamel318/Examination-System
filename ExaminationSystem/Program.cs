using System.Diagnostics;

namespace ExaminationSystem
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Subject subject = new Subject(10 , "c#");
			subject.CreateExam();
            Console.Clear();
            Console.Write("Do you want start exam (y | n): ");
			if(Console.ReadLine() == "y" )
			{
				Stopwatch sw = new Stopwatch();
				sw.Start();
				Console.Clear() ;
				subject.Exam.ShowExam();

				if(subject.Exam.TimeOfExam >= sw.Elapsed.TotalMinutes)
				{
					Console.WriteLine($"The elapsed time = {sw.Elapsed.TotalMinutes}");
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Sorry time is Finished!");
				}
            }
		}
	}
}
