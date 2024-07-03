using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
	internal class Subject
	{
        public Subject(int Id , string Name)
        {
			this.Id = Id;
			this.Name = Name;
		}
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }
        
        public void CreateExam()
        {
            int ExamType = 0, NumOfQues = 0, TimeOfExam = 0	;
			SetConfigAboutExam(ref ExamType, ref NumOfQues, ref TimeOfExam);

			if (ExamType == 1)
            {             
				Exam = GitFinalExam(NumOfQues, TimeOfExam);
			}


			else if (ExamType == 2)
			{
				Exam = GitPracticalExam(NumOfQues, TimeOfExam);
			}
			else
			{
				Console.WriteLine("Not Exist");
			}

		}
		private int GetConfigFromUser(string messege , string errMessege = "Unsuitable Choice")
		{
			bool flag; int configValue;
			do
			{
				Console.Write(messege);
				flag = int.TryParse(Console.ReadLine(), out configValue);
				if (!flag)
				{
					Console.WriteLine(errMessege);
				}
			} while (!flag);
			return configValue;
		}

		private void SetConfigAboutExam(ref int ExamType , ref int NumOfQues , ref int TimeOfExam)
		{
			ExamType = GetConfigFromUser("Type of exam (1 for Final , 2 for Practical : ");

			Console.Clear();

			NumOfQues = GetConfigFromUser("Enter number of questions : ");

			Console.Clear();

			TimeOfExam = GetConfigFromUser("Enter time of exam : ");

			Console.Clear();
		}
        private MCQ PrepareMcqQuestion()
        {
			MCQ Ques = new MCQ();
			Console.WriteLine("Enter body of question : ");
			Ques.Body = Console.ReadLine();
			Ques.Mark = GetConfigFromUser("Enter Mark : ","Must be number");
			for (int j = 0; j < Ques.AnswerList.Length; j++)
			{
				Console.Write($"Choise number {j + 1} : ");
				Ques.AnswerList[j] = new Answer(j + 1, Console.ReadLine());

			}
			do
			{
				Ques.RightAnswerId = GetConfigFromUser("Enter right answer : ", "Must be from 1 to 3");
			} while (!(Ques.RightAnswerId >= 1 && Ques.RightAnswerId <= 3));
			Console.WriteLine("================================");

			return Ques;
		}

		private TrueOrFalse PrepareTrueOrFalseQuestion()
		{
			TrueOrFalse Ques = new TrueOrFalse();
			Console.WriteLine("Enter body of question : ");
			Ques.Body = Console.ReadLine();
			Ques.Mark = GetConfigFromUser("Enter Mark : ", "Must be number");
			do
			{
				Ques.RightAnswerId = GetConfigFromUser("Enter right answer : ", "Must be from 1 to 3");
			} while (!(Ques.RightAnswerId == 1 || Ques.RightAnswerId == 2));
			Console.WriteLine("================================");

			return Ques;
		}

		private FinalExam GitFinalExam(int NumOfQues ,int TimeOfExam)
		{
			List<MCQ> McqQuestions = new List<MCQ>();
			List<TrueOrFalse> TFQuestions = new List<TrueOrFalse>();
			for (int i = 1; i <= NumOfQues; i++)
			{
				if (GetConfigFromUser($"Type of question number {i} (1 for MCQ , 2 for TF) : ") == 1)
					McqQuestions.Add(PrepareMcqQuestion());

				else
					TFQuestions.Add(PrepareTrueOrFalseQuestion());
			}
			return new FinalExam(TFQuestions, McqQuestions, TimeOfExam);
		}

		private PracticalExam GitPracticalExam(int NumOfQues, int TimeOfExam)
		{
			List<MCQ> McqQuestions = new List<MCQ>();

			for (int i = 1; i <= NumOfQues; i++)
			{
				Console.WriteLine($"Question{i}:");
				McqQuestions.Add(PrepareMcqQuestion());
			}
			return new PracticalExam(McqQuestions, TimeOfExam);
		}

	}
}
