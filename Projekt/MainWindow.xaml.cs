using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using System.Timers;
using System.Diagnostics;
using Microsoft.Win32;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
        

        // Weryfikacja czy zostaje wpisana wartosc liczbowa
        public static int X;
        
        private void TextBox_Table_Do_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            e.Handled = !int.TryParse(e.Text, out int result);
            TextBox_Table_Do.MaxLength = 4;
        }
        
 
        // Tworzenie tablicy 
        public static int SelectionSortCount = 1;
        public static int InsertionSortCount = 1;
        public static int BubbleSortCount = 1;
        public static double QuickSortCount = 1;
        // Zmienna umozliwiajaca tworzenie tablicy bez dodawania do generacji
        public static bool ArrIsEmpty; 

      
        private void Button_Table_Do_Click(object sender, RoutedEventArgs e)
        {
            
            Random rnd = new Random();
            X = int.Parse(TextBox_Table_Do.Text);
            int[] array1 = new int[X];
            if (X == 0)
            {
                SelectionSortCount = 0;
                InsertionSortCount = 0;
                BubbleSortCount = 0;    
                QuickSortCount= 0;
            }
            for (int i = 0; i < X; i++)
            {
                array1[i] = rnd.Next(0, 1000);
                ListView.Items.Add(array1[i]);
                  
                if (X > 0)
                {
                    ArrIsEmpty = false;
                }
                else
                {
                    ArrIsEmpty = true;
                }

            }
            Button_Table_Do.IsEnabled = false;
            Button_Table_Remove.IsEnabled = true;

        }
        
        //Deklaracja listy przyjmujacej zmienne do sortowania 
        public static List <int> elementy1 = new List<int>();
        
        // Deklaracja zmiennych niezbednych do wykresow SelectionSort
        public static List<int> lista=new List<int>();
        public static List<long> listaT = new List<long>();
        public static Stopwatch zegar;
        // Deklaracja zmiennych niezbednych do wykresow InsertionSort
        public static List<int> listaIS = new List<int>();
        public static List<long> listaTIS = new List<long>();
        public static Stopwatch zegarIS;
        // Deklaracja zmiennych niezbednych do wykresow BubbleSort
        public static List<int> listaBS = new List<int>();
        public static List<long> listaTBS = new List<long>();
        public static Stopwatch zegarBS;
        // Deklaracja zmiennych niezbednych do wykresow QuickSort
        public static List<double> listaQS = new List<double>();
        public static List<long> listaTQS = new List<long>();
        public static Stopwatch zegarQS;

        // Funkcja Sortowanie przez wybieranie 
        public static class SelectionSort
        {
            public static void Sort<T>(T[] array) where T : IComparable
            {
                zegar = new Stopwatch();
                zegar.Start();
                for (int i = 0; i < array.Length - 1; i++)
                {
                    
                    int minIndex = i;
                    T minValue = array[i];
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j].CompareTo(minValue) < 0)
                        {
                            minIndex = j;
                            minValue = array[j];
                        }
                    }
                    Swap(array, i, minIndex);
                        SelectionSortCount++;
                    lista.Add(SelectionSortCount);
                    listaT.Add(zegar.ElapsedMilliseconds);
                }
            }
        }

        // Funkcja Swap umozliwiajaca sortowania
        private static void Swap<T>(T[] array, int first, int second) where T : IComparable
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        // Zdarzenie posortowanie przez wybieranie
        private void Button_Choosing_Sort_Click(object sender, RoutedEventArgs e)
        {
            int[] array1 = new int[ListView.Items.Count];
            for (int i = 0; i < ListView.Items.Count; i++)
            {
                array1[i] = (int)ListView.Items[i];
            }
            Button_Choosing_Sort.IsEnabled = false;

            SelectionSort.Sort(array1);
            
        }

        // Funkcja Sortowanie przez wstawianie 
        public static class InsertionSort
        {
            
            public static void Sort<T>(T[] array) where T : IComparable
            {
                zegarIS = new Stopwatch();
                zegarIS.Start();
                for (int i = 1; i < array.Length; i++)
                {
                    int j = i;
                    while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                    {
                        Swap(array, j, j - 1);
                        j--;
                    }
                    InsertionSortCount++;
                    listaIS.Add(InsertionSortCount);
                    listaTIS.Add(zegarIS.ElapsedMilliseconds);

                }
            }
        }

        // Zdarzenie sortowanie przez wstawianie
        private void Button_Insert_Sorting_Click(object sender, RoutedEventArgs e)
        {
            int[] array1 = new int[ListView.Items.Count];
            for (int i = 0; i < ListView.Items.Count; i++)
            {
                array1[i] = (int)ListView.Items[i];
            }
            Button_Insert_Sorting.IsEnabled = false;

            InsertionSort.Sort(array1);
            
        }
        
       // Funkcja Sortowanie bąbelkowe
        public static class BubbleSort
        {

            public static T[] Sort<T>(T[] array) where T : IComparable
            {
                zegarBS = new Stopwatch();
                zegarBS.Start();
                for (int i = 0; i < array.Length; i++)
                {
                    bool isAnyChange = false;
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j].CompareTo(array[j + 1]) > 0)
                        {
                            isAnyChange = true;
                               Swap(array, j, j + 1);
                        }
                        
                    }
                    if (!isAnyChange)
                    {
                        break;
                    }
                    BubbleSortCount++;
                    listaBS.Add(BubbleSortCount);
                    listaTBS.Add(zegarBS.ElapsedMilliseconds);
                }
                return array;
                
            }
        }

        // Zdarzenie sortowanie bąbelkowe
        private void Button_Bubble_Sorting_Click(object sender, RoutedEventArgs e)
        {
            int[] array1 = new int[ListView.Items.Count];
            for (int i = 0; i < ListView.Items.Count; i++)
            {
                array1[i] = (int)ListView.Items[i];
            }
            Button_Bubble_Sorting.IsEnabled = false;

            BubbleSort.Sort(array1);
            
        }

        // Funkcja sortowanie szybkie
        public static void QuickSort(int[] array, int left, int right)
        {
            zegarQS = new Stopwatch();
            zegarQS.Start();
        
            
                var i = left;
                var j = right;
                var pivot = array[(left + right) / 2];
                while (i < j)
                {

                    while (array[i] < pivot)
                        i++;
                    while (array[j] > pivot)
                        j--;
                    if (i <= j)
                    {
                        // swap
                        var tmp = array[i];
                        array[i++] = array[j];  // ++ and -- inside array braces for shorter code
                        array[j--] = tmp;

                    }
                QuickSortCount=array.Length;
                listaQS.Add(QuickSortCount);
                listaTQS.Add(zegarQS.ElapsedMilliseconds);
                }
                if (left < j)
                    QuickSort(array, left, j);
                if (i < right)
                    QuickSort(array, i, right);

        }

        // Zdarzenie sortowanie szybkie
        private void Button_Quick_Sort_Click(object sender, RoutedEventArgs e)
        {
            int[] array1 = new int[ListView.Items.Count];
            for (int i = 0; i < ListView.Items.Count; i++)
            {
                array1[i] = (int)ListView.Items[i];
            }
            Button_Quick_Sort.IsEnabled = false;

            QuickSort(array1,0,array1.Length-1);
            

        }

        private void Button_Plots_Click(object sender, RoutedEventArgs e)
        {
            Window1 okno = new Window1();
            okno.Show();

        }
        // Czyszczenie danych wykresowych 
        public static void RemovingAll()
        {
            SelectionSortCount = 1;
            InsertionSortCount = 1;
            BubbleSortCount = 1;
            QuickSortCount = 1;
            lista.Clear();
            listaT.Clear();
            listaBS.Clear();
            listaIS.Clear();
            listaQS.Clear();
            listaTBS.Clear();
            listaTIS.Clear();
            listaTQS.Clear();
        }
        private void Button_Table_Remove_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Table_Do.Clear();
            ListView.Items.Clear();
            
            Button_Bubble_Sorting.IsEnabled = true;
            Button_Choosing_Sort.IsEnabled = true;
            Button_Insert_Sorting.IsEnabled = true;
            Button_Quick_Sort.IsEnabled = true;
            Button_Table_Do.IsEnabled = true;

            RemovingAll();
            MessageBox.Show("Usunięto wszystkie tabele i wykresy, ponowne uzyskanie wykresow bez sortowania tabeli spowoduje \n BŁĄD I WYŁĄCZENIE PROGRAMU !!!!");


    }
        // Importowanie tabeli
        private void Button_Table_Import_Click(object sender, RoutedEventArgs e)
        {
            ListView.Items.Clear();
            RemovingAll();
            MessageBox.Show("Nastąpi przekierowanie do wyboru pliku");
            OpenFileDialog openFileDialog= new OpenFileDialog();
            
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == true)
            {
            string filename = openFileDialog.FileName;
                foreach (string line in System.IO.File.ReadLines(filename))
                {
                ListView.Items.Add(int.Parse(line));
                }
            }
            

        }
        // Robienie wlasnej tabeli - otwieranie okna 
        private void Button_Table_Do_Yourself_Click(object sender, RoutedEventArgs e)
        {
            
            Window2 window2 = new Window2();
            window2.Show();
            ListView.Items.Clear();
            RemovingAll();
        }
        // Okna informacyjne
        private void Button_Info_SS_Click(object sender, RoutedEventArgs e)
        {
            WindowSSInfo windowSS = new WindowSSInfo();
            windowSS.Show();
        }

        private void Button_Info_IS_Click(object sender, RoutedEventArgs e)
        {
            WindowISInfo windowIS = new WindowISInfo();
            windowIS.Show();
        }

        private void Button_Info_BS_Click(object sender, RoutedEventArgs e)
        {
            WindowBSInfo windowBS = new WindowBSInfo();
            windowBS.Show();
        }

        private void Button_Info_SS_QS_Click(object sender, RoutedEventArgs e)
        {
            WindowQSInfo windowQS = new WindowQSInfo();
            windowQS.Show();
        }
        // Żeby nie mozna bylo wrzucic spacji do textboxa:
        private void TextBox_Table_Do_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox_Table_Do.Text = string.Concat(TextBox_Table_Do.Text.Where(char.IsLetterOrDigit));
            if (string.IsNullOrEmpty(TextBox_Table_Do.Text))
                Button_Table_Do.IsEnabled = false;
            else
                Button_Table_Do.IsEnabled = true;
            ;
        }
        // Odpalanie wizualizacji
        private void Animation_SS_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
        }
        //Wczytywanie tabeli z tabeli wlasnej
        private void Button_Do_Yourself_Loaded_Click(object sender, RoutedEventArgs e)
        {
            if (Window2.isButtonExportClicked)
            {
                for (int i = 0; i < Window2.Exported.Count; i++)
                {
                    ListView.Items.Add(Window2.Exported[i]);
                }
                MessageBox.Show("Wczytano tabelę");
            }
            else
                MessageBox.Show("Nie udało się wczytać tabeli");
                          
        }

        
    }
}
