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
    /// Interaction logic for SaveResultWindow.xaml
    /// </summary>
    public partial class SaveResultWindow : Window
    {
        
        public SaveResultWindow(int result,string date)
        {
            InitializeComponent();
            LblResult.Content = result;
            LblDate.Content = date;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = TbName.Text;
            string result = LblResult.Content.ToString() ;
            string date = LblDate.Content.ToString();
            string fileNameOfResult = "result.txt";
            File.AppendAllText(fileNameOfResult, "\n"+name+";"+result+";"+date);
            this.Close();
        }
    }
}
