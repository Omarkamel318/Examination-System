using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
	internal class Question
	{
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public int ChoiseAnswerId { get; set; }
        public int RightAnswerId { get; set; }


		public Question(string header)
        {
            Header = header;

            if (header == "MCQ")
                AnswerList = new Answer[3];
            else
                AnswerList = new Answer[2] { new Answer(1, "True"), new Answer(2, "False") };
        }
    }
}
