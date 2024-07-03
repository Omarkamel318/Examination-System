using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
	internal class FinalExam : Exam
	{
		public List<TrueOrFalse> TFQuestions { get; set; }

		public FinalExam(List<TrueOrFalse> TFQuestions , List<MCQ> McqQuestions , int TimeOfExam) :base(TimeOfExam)
        {
            this.TFQuestions = TFQuestions;
            this.McqQuestions = McqQuestions;
        }
        public override void ShowExam()
		{
			GetAnswerForQuestions(McqQuestions);
			GetAnswerForQuestions(TFQuestions);
			Console.Clear();
			GetSolutions(McqQuestions);
			GetSolutions(TFQuestions);
			Console.WriteLine("================================================");
			GetGrade();
		}





	}
}
