using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HCI_P1_Game.Model;
namespace HCI_P1_Game
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private int CurrentQuestion=1;
        private Random random = new Random();
        public GameWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            //za pravljenje novog using
            //if (File.Exists(fileName))
            //using(FileStream fs = File.Create(fileName)){
            //    Byte[] title = new UTF8Encoding(true).GetBytes("pocetak");
            //    fs.Write(title, 0, title.Length);
            // } a za dodavanje  File.AppendAllText(fileName, "novooo");


            List<Question> questionList1 = new List<Question>();
            List<Question> questionList2 = new List<Question>();
            List<Question> questionList3 = new List<Question>();
            string fileName = "questions.txt";
            
            string[] allLines = File.ReadAllLines(fileName);
            string []lineParts;
            foreach (string line in allLines)
            {
                lineParts = line.Split(';');
                Question q = new Question
                {
                    Id = int.Parse(lineParts[0]),
                    Category = int.Parse(lineParts[1]),
                    QuestionText = lineParts[2],
                    Answer1 = lineParts[3],
                    Answer2 = lineParts[4],
                    Answer3 = lineParts[5],
                    Answer4 = lineParts[6],
                    CorrectAnswer = lineParts[3]

                };
                if (q.Category == 1)
                    questionList1.Add(q);
                else if (q.Category == 2)
                    questionList2.Add(q);
                else
                    questionList3.Add(q);
            }

            //int questionNumber = random.Next(questionList1.Count )+1;
            int questionNumber = 14;// ovo mora rijesiti
            TbQuestion.Text = questionList1[questionNumber].QuestionText;
            BtnAnswerA.Content = questionList1[questionNumber].Answer1;
            BtnAnswerA.Tag = questionList1[questionNumber].Answer1;
            BtnAnswerB.Content = questionList1[questionNumber].Answer2;
            BtnAnswerB.Tag = questionList1[questionNumber].Answer2;
            BtnAnswerC.Content = questionList1[questionNumber].Answer3;
            BtnAnswerC.Tag = questionList1[questionNumber].Answer3;
            BtnAnswerD.Content = questionList1[questionNumber].Answer4;
            BtnAnswerD.Tag = questionList1[questionNumber].Answer4;

        }

        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            string answer = (sender as Button).Tag.ToString();
            TbAnswer.Text = answer;
        }
    }
}
