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
using System.Threading;
namespace HCI_P1_Game
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private int CurrentQuestionNumber=0;
        private Question CurrentQuestion = null;
        private int CurrentPrice = 0;
        private Random random = new Random();
        private string fileNameOfResult = "result.txt";
        private List<Label> PriceLabels = new List<Label>();
        private List<Question> questionList1 = new List<Question>();
        private List<Question> questionList2 = new List<Question>();
        private List<Question> questionList3 = new List<Question>();
        private int sillNumber = 0;
        private List<Button> buttonList = new List<Button>();
        public GameWindow(bool resultOnly)
        {
            InitializeComponent();
            InitializeWindow();
            if (resultOnly)
                ClearWindow();
        }

        private void InitializeWindow()
        {
           
            
            if (!File.Exists(fileNameOfResult))
                File.Create(fileNameOfResult);
   

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
            LbPrice1.Tag = 100;
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

            DgResult.ItemsSource = LoadCollectionData();
            

        }

        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            string answer = (sender as Button).Tag.ToString();
            InfoWindow areYouSureWindow = new InfoWindow("Da li ste sigurni ?","DA","NE");
            bool? result = areYouSureWindow.ShowDialog();
            if (result ?? false)
            {
                Thread.Sleep(1000);
                if (answer.Equals(CurrentQuestion.CorrectAnswer))
                {

                    string CurrentPriceLikeString = PriceLabels[CurrentQuestionNumber - 1].Content.ToString();
                    CurrentPrice = int.Parse(StringWithoutSpaces(CurrentPriceLikeString));
                    if (CurrentQuestionNumber == 15)//krja igre osovjen milion
                    {
                        InfoWindow nextQuestionWindow = new InfoWindow("Čestitamo,osvojili ste milion !", "Sačuvaj rezultat", "Igraj ponovo");
                        bool? result1 = nextQuestionWindow.ShowDialog();
                        if (result1 ?? false)//osvojen milion,hoce da sacuva
                        {

                            new SaveResultWindow(CurrentPrice, DateTime.Now.ToString("dd-MM-yyy")).ShowDialog();
                            DgResult.ItemsSource = null;
                            DgResult.ItemsSource = LoadCollectionData();
                            ClearWindow();
                        }
                        else//samo hoce novu igru
                        {

                            ClearWindow();
                            SetNewQuestion();

                        }
                    }
                    else
                    {
                        InfoWindow nextQuestionWindow = new InfoWindow("Odgovor je tačan !", "Sledeće pitanje", "Kraj igre,sačuvaj rezultat");
                        bool? result1 = nextQuestionWindow.ShowDialog();
                        if (result1 ?? false)//tacan odgovor i sledece pitanje
                        {

                            SetNewQuestion();
                        }
                        else
                        {

                            new SaveResultWindow(CurrentPrice, DateTime.Now.ToString("dd-MM-yyy")).ShowDialog();
                            DgResult.ItemsSource = null;
                            DgResult.ItemsSource = LoadCollectionData();
                            ClearWindow();

                        }
                    }
                    
                   
                }
                else//odgovor nije tacan
                {
                    InfoWindow saveScoreWindow = new InfoWindow("Odgovor nije tačan !", "Sačuvaj rezultat", "Ponovna igra");
                    bool? result2 = saveScoreWindow.ShowDialog();
                    if(result2 ?? false)//hoce da sacuva rezulta
                    {
                        if(sillNumber==1)
                            new SaveResultWindow(1000, DateTime.Now.ToString("dd-MM-yyy")).ShowDialog();
                        else if(sillNumber==2)
                            new SaveResultWindow(16000, DateTime.Now.ToString("dd-MM-yyy")).ShowDialog();
                        else
                            new SaveResultWindow(CurrentPrice, DateTime.Now.ToString("dd-MM-yyy")).ShowDialog();
                        DgResult.ItemsSource = null;
                        DgResult.ItemsSource = LoadCollectionData();
                        ClearWindow();
                    }
                    else//nece da sacuva rezultat,ponovna igra
                    {
                        ClearWindow();
                        SetNewQuestion();
                    }
                }
            }
           
            
        }

        private string StringWithoutSpaces(string currentPriceLikeString)
        {
            string trimmed = currentPriceLikeString.Replace(" ", String.Empty);
            return trimmed;

        }

        private void ClearWindow()
        {
            
            TbQuestion.Clear();
            BtnAnswerA.Content = "";
            BtnAnswerB.Content = "";
            BtnAnswerC.Content = "";
            BtnAnswerD.Content = "";
            for(int i = 0; i < PriceLabels.Count; i++)
            {
                if(i==4 || i==8 || i==14)
                    PriceLabels[i].Background = (System.Windows.Media.Brush)Application.Current.Resources["BackgroundColorForSillPriceLabel"];
                else
                    PriceLabels[i].Background = (System.Windows.Media.Brush)Application.Current.Resources["CornflowerBlue"];
            }
                
            CurrentQuestion = null;
            CurrentQuestionNumber = 0;
            CurrentPrice = 0;
            sillNumber = 0;
        }

        private void SetNewQuestion()
        {
            if(CurrentQuestionNumber==0)
                LbPrice1.Background = (System.Windows.Media.Brush)Application.Current.Resources["BackgroundColorForPriceLabel"];
            CurrentQuestionNumber++;
            Label lb = PriceLabels[CurrentQuestionNumber - 1];
            if (CurrentQuestionNumber > 1)
            {
                Label lbTmp = PriceLabels[CurrentQuestionNumber - 2];
                if(CurrentQuestionNumber-2==4 || CurrentQuestionNumber - 2 == 8 || CurrentQuestionNumber - 2 == 15)
                {
                    lbTmp.Background = (System.Windows.Media.Brush)Application.Current.Resources["BackgroundColorForSillPriceLabel"];
                    if (CurrentQuestionNumber - 2 == 4)
                        sillNumber = 1;
                    else
                        sillNumber = 2;

                }
                else
                    lbTmp.Background = (System.Windows.Media.Brush)Application.Current.Resources["CornflowerBlue"];


            }
            lb.Background = (System.Windows.Media.Brush)Application.Current.Resources["BackgroundColorForPriceLabel"];
            if (CurrentQuestionNumber <=5)
            {
                buttonList.Add(BtnAnswerA);
                buttonList.Add(BtnAnswerB);
                buttonList.Add(BtnAnswerC);
                buttonList.Add(BtnAnswerD);
                int questionNumber = random.Next(questionList1.Count) ;
                Question q = questionList1[questionNumber];
                CurrentQuestion = q;
                TbQuestion.Text = q.QuestionText;
                Button b = GetRandomButton();
                b.Content = q.Answer1;
                b.Tag = q.Answer1;

                b = GetRandomButton();
                b.Content = q.Answer2;
                b.Tag = q.Answer2;

                b = GetRandomButton();
                b.Content = q.Answer3;
                b.Tag = q.Answer3;

                b = GetRandomButton();
                b.Content = q.Answer4;
                b.Tag = q.Answer4;
                

            }else if(CurrentQuestionNumber>5 && CurrentQuestionNumber <= 10)
            {
                buttonList.Add(BtnAnswerA);
                buttonList.Add(BtnAnswerB);
                buttonList.Add(BtnAnswerC);
                buttonList.Add(BtnAnswerD);
                int questionNumber = random.Next(questionList2.Count);
                Question q = questionList2[questionNumber];
                CurrentQuestion = q;
                TbQuestion.Text = q.QuestionText;
                Button b = GetRandomButton();
                b.Content = q.Answer1;
                b.Tag = q.Answer1;

                b = GetRandomButton();
                b.Content = q.Answer2;
                b.Tag = q.Answer2;

                b = GetRandomButton();
                b.Content = q.Answer3;
                b.Tag = q.Answer3;

                b = GetRandomButton();
                b.Content = q.Answer4;
                b.Tag = q.Answer4;
            }
            else
            {
                buttonList.Add(BtnAnswerA);
                buttonList.Add(BtnAnswerB);
                buttonList.Add(BtnAnswerC);
                buttonList.Add(BtnAnswerD);
                int questionNumber = random.Next(questionList3.Count);
                Question q = questionList3[questionNumber];
                CurrentQuestion = q;
                TbQuestion.Text = q.QuestionText;
                Button b = GetRandomButton();
                b.Content = q.Answer1;
                b.Tag = q.Answer1;

                b = GetRandomButton();
                b.Content = q.Answer2;
                b.Tag = q.Answer2;

                b = GetRandomButton();
                b.Content = q.Answer3;
                b.Tag = q.Answer3;

                b = GetRandomButton();
                b.Content = q.Answer4;
                b.Tag = q.Answer4;
            }

           
        }
        private Button GetRandomButton()
        {
            int c = buttonList.Count;
            int radnomIndex=random.Next(c);
            Button res = buttonList[radnomIndex];
            buttonList.Remove(res);
            return res;

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            ClearWindow();
            SetNewQuestion();
        }
        private List<GameResult> LoadCollectionData()
        {
            List<GameResult> gameResults = new List<GameResult>();

            string[] allLines = File.ReadAllLines(fileNameOfResult);
            string[] lineParts;
            foreach (string line in allLines)
            {
                lineParts = line.Split(';');
                GameResult gr = new GameResult()
                {
                    Ime = lineParts[0],
                    Rezultat = int.Parse(lineParts[1]),
                    Datum = lineParts[2]
                };
                gameResults.Add(gr);
            }
            gameResults.Sort((x, y) => y.Rezultat.CompareTo(x.Rezultat));

            return gameResults;
           
        }
    }
}
