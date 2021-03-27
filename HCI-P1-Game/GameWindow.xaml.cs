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
        private int CurrentQuestionNumber=0;
        private Random random = new Random();
        private Question CurrentQuestion = null;
        private List<Label> PriceLabels = new List<Label>();
        private List<Question> questionList1 = new List<Question>();
        private List<Question> questionList2 = new List<Question>();
        private List<Question> questionList3 = new List<Question>();
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
            PriceLabels.Add(LbPrice1);
            PriceLabels.Add(LbPrice2);
            PriceLabels.Add(LbPrice3);
            PriceLabels.Add(LbPrice4);
            PriceLabels.Add(LbPrice5);
            PriceLabels.Add(LbPrice6);
            PriceLabels.Add(LbPrice7);
            PriceLabels.Add(LbPrice8);
            PriceLabels.Add(LbPrice9);
            PriceLabels.Add(LbPrice10);
            PriceLabels.Add(LbPrice11);
            PriceLabels.Add(LbPrice12);
            PriceLabels.Add(LbPrice13);
            PriceLabels.Add(LbPrice14);
            PriceLabels.Add(LbPrice15);
            
            SetNewQuestion();
            
            

        }

        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            string answer = (sender as Button).Tag.ToString();
            AnswerCheckWindow answerCheckWindow = new AnswerCheckWindow();
            bool? result = answerCheckWindow.ShowDialog();
            if (result ?? false)
            {
               
                if (answer.Equals(CurrentQuestion.CorrectAnswer))
                {
                    TbAnswer.Text = "Odgovor je tacan"+ CurrentQuestionNumber;
                    SetNewQuestion();
                }
                else
                {
                    TbAnswer.Text = "Odgovor nije tacan";
                }
            }
            else
            {
                TbAnswer.Text = "ne";
            }
            //TbAnswer.Text = answer;
        }
        private void SetNewQuestion()
        {
            CurrentQuestionNumber++;
            Label lb = PriceLabels[CurrentQuestionNumber - 1];
            if (CurrentQuestionNumber > 1)
            {
                Label lbTmp = PriceLabels[CurrentQuestionNumber - 2];
                lbTmp.Background = (System.Windows.Media.Brush)Application.Current.Resources["BackgroundColor"];
            }
            lb.Background = (System.Windows.Media.Brush)Application.Current.Resources["BackgroundColorForPriceLabel"];
            if (CurrentQuestionNumber <=5)
            {
                int questionNumber = random.Next(questionList1.Count) ;
                Question q = questionList1[questionNumber];
                CurrentQuestion = q;
                TbQuestion.Text = q.QuestionText;
                BtnAnswerA.Content = q.Answer1;
                BtnAnswerA.Tag = q.Answer1;
                BtnAnswerB.Content = q.Answer2;
                BtnAnswerB.Tag = q.Answer2;
                BtnAnswerC.Content = q.Answer3;
                BtnAnswerC.Tag = q.Answer3;
                BtnAnswerD.Content = q.Answer4;
                BtnAnswerD.Tag = q.Answer4;
                

            }else if(CurrentQuestionNumber>5 && CurrentQuestionNumber <= 10)
            {
                int questionNumber = random.Next(questionList2.Count);
                Question q = questionList2[questionNumber];
                CurrentQuestion = q;
                TbQuestion.Text = q.QuestionText;
                BtnAnswerA.Content = q.Answer1;
                BtnAnswerA.Tag = q.Answer1;
                BtnAnswerB.Content = q.Answer2;
                BtnAnswerB.Tag = q.Answer2;
                BtnAnswerC.Content = q.Answer3;
                BtnAnswerC.Tag = q.Answer3;
                BtnAnswerD.Content = q.Answer4;
                BtnAnswerD.Tag = q.Answer4;
            }
            else
            {
                int questionNumber = random.Next(questionList3.Count);
                Question q = questionList3[questionNumber];
                CurrentQuestion = q;
                TbQuestion.Text = q.QuestionText;
                BtnAnswerA.Content = q.Answer1;
                BtnAnswerA.Tag = q.Answer1;
                BtnAnswerB.Content = q.Answer2;
                BtnAnswerB.Tag = q.Answer2;
                BtnAnswerC.Content = q.Answer3;
                BtnAnswerC.Tag = q.Answer3;
                BtnAnswerD.Content = q.Answer4;
                BtnAnswerD.Tag = q.Answer4;
            }

           
        }
    }
}
