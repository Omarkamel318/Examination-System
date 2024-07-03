using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
	internal class PracticalExam : Exam
	{
        public PracticalExam(List<MCQ> McqQuestions ,int TimeOfExam) : base(TimeOfExam)
        {
            this.McqQuestions = McqQuestions;
        }
        public List<MCQ> McqQuestions { get; set; }

		public override void ShowExam()
		{
			GetAnswerForQuestions(McqQuestions);
			Console.Clear();
			GetSolutions(McqQuestions);
			Console.WriteLine("================================================");
			GetGrade();
		}
	}
}
