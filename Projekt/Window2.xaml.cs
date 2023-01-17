using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        public static bool? kkk;
        private void Button_Yourself_Click(object sender, RoutedEventArgs e)
        {
            
            ListView_Yourself.Items.Add(int.Parse(TextBox_Yourself.Text));
            TextBox_Yourself.Clear();
           
        }

        private void TextBox_Yourself_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
          
                e.Handled = !int.TryParse(e.Text, out int result);//TYLKO INT
            TextBox_Yourself.MaxLength = 4;
             
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            ListView_Yourself.Items.Clear();
            kkk = null;
            Button_Yourself.IsEnabled = true;
            Button_Save.IsEnabled= true;

        }

       
        public static bool isButtonExportClicked;
        public static List <int> Exported = new List <int>();   
        private void Button_GoToSort_Click(object sender, RoutedEventArgs e)
        {
            isButtonExportClicked = true;
            for(int i=0; i<ListView_Yourself.Items.Count;i++)
            {
                Exported.Add((int)ListView_Yourself.Items[i]);
                
            }
            MessageBox.Show("Przechodzimy do sortowania");
            Window2 window2 = new Window2();
            this.Close();
               
        }
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            Button_Yourself.IsEnabled= false;
            Button_Save.IsEnabled= false;
            int X = ListView_Yourself.Items.Count;
            int[] array = new int[X];
            for (int i = 0; i<X;i++)
            {
                array[i] = (int)ListView_Yourself.Items[i];
            }
            MessageBox.Show("Zapisano tabelę");
        }
        
    }
}
