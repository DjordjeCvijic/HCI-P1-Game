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


            List<Question> allQuestions = new List<Question>();
            string fileName = "questions.txt";
            
            string[] allLines = File.ReadAllLines(fileName);
            foreach (string line in allLines)
            {
                Console.WriteLine(line);
                LBForQuestion.Items.Add(line);
            }
        }
    }
}
