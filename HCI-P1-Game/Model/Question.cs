using System;
using System.Collections.Generic;
using System.Text;

namespace HCI_P1_Game.Model
{
    class Question
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string QuestionText { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string CorrectAnswer { get; set; }
    
    }
}
