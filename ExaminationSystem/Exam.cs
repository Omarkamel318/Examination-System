using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
	internal abstract class Exam
	{
        public Exam(int TimeOfExam)
        {
			this.TimeOfExam = TimeOfExam;
		}
        public int TimeOfExam { get; set; }
        public int NumberOfQuestion { get; set; }
		public List<MCQ> McqQuestions { get; set; }

		protected int grade = 0;
		protected int Totalgrade = 0;
		public abstract void ShowExam();

		protected void GetAnswerForQuestions<T>(List<T> questions) where T : Question
		{
			foreach (var q in questions)
			{
				Totalgrade += q.Mark;
				Console.WriteLine(q.Header);
				Console.WriteLine(q.Body);
				for (var i = 0; i < q.AnswerList.Length; i++)
				{
					Console.Write($"{q.AnswerList[i].Id}.{q.AnswerList[i].Text}       ");
				}
				Console.WriteLine();
				Console.WriteLine("-------------------------------------------");
				q.ChoiseAnswerId = Convert.ToInt32(Console.ReadLine());
				if (q.ChoiseAnswerId == q.RightAnswerId)
					grade += q.Mark;
				Console.WriteLine("===========================================");
			}

			///foreach (var q in TFQuestions)
			///{
			///	Totalgrade += q.Mark;
			///	Console.WriteLine(q.Header);
			///	Console.WriteLine(q.Body);
			///	for (var i = 0; i < q.AnswerList.Length; i++)
			///	{
			///		Console.Write($"{q.AnswerList[i].Id}.{q.AnswerList[i].Text}       ");
			///	}
			///	Console.WriteLine();
			///	Console.WriteLine("-------------------------------------------");
			///	q.ChoiseAnswerId = Convert.ToInt32(Console.ReadLine());
			///	if (q.ChoiseAnswerId == q.RightAnswerId)
			///		grade += q.Mark;
			///	Console.WriteLine("===========================================");
			///}
		}

		protected void GetSolutions<T>(List<T> questions) where T : Question
		{
			foreach (var q in questions)
			{
				Console.WriteLine(q.Body);
				Console.WriteLine($"=>{q.RightAnswerId}.{q.AnswerList[q.RightAnswerId - 1].Text}");
				Console.WriteLine("--------------------------------------------");
			}
			///foreach (var q in TFQuestions)
			///{
			///	Console.WriteLine(q.Body);
			///	Console.WriteLine($"=>{q.RightAnswerId}.{q.AnswerList[q.RightAnswerId - 1].Text}");
			///	Console.WriteLine("--------------------------------------------");
			///}
		}

		protected void GetGrade() => Console.WriteLine($"Grade is {grade} from {Totalgrade}");


	}
}
