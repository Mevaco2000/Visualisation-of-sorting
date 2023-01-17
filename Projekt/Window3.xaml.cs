using OxyPlot;
using ScottPlot.Styles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        public static Rectangle DrawRectangle(double wysokosc, double grubosc)
        {
            Rectangle rect = new Rectangle
            {
                Width = grubosc,
                Height = wysokosc,
                Fill = Brushes.AliceBlue,


            };
            return rect;
        }
        public static void TableDo()
        {
            Random rnd = new Random();
            for (int i = 0; i < (int)Wielkosc; i++)
            {
                
                int x = rnd.Next(0, 1000);
                elementy.Add(x);
                
            }
        
        
        
        }
        public static List <int> elementy = new List<int>(); // lista na sortowanie itd
         // lista na niesortowane itd
        public static double Wielkosc;
        public static void Swap(List<int> array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }



        private static void SwapRectangle(Rectangle rect1, Rectangle rect2)
        {
            double X = rect1.Height;
            rect1.Height = rect2.Height;
            rect2.Height = X;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button.IsEnabled = false;
            TableDo();
            for (int i = 0; i < elementy.Count; i++)
            {
                Rectangle rect = DrawRectangle(elementy[i] / 2, canv.ActualWidth / elementy.Count);
                canv.Children.Add(rect);
                Canvas.SetLeft(rect, i * (canv.ActualWidth / elementy.Count));
                Canvas.SetTop(rect, 0);

            }

        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox.SelectedIndex)
            {
                case 0:
                    // Sortowanie przez wybieranie
                    for (int i = 0; i < elementy.Count - 1; i++)
                    {
                        int minIndex = i;
                        int minValue = elementy[i];
                        for (int j = i + 1; j < elementy.Count; j++)
                        {
                            if (elementy[j].CompareTo(minValue) < 0)
                            {
                                minIndex = j;
                                minValue =elementy[j];
                            }
                        }
                        Swap(elementy, i, minIndex);
                        SwapRectangle((Rectangle)canv.Children[i], (Rectangle)canv.Children[minIndex]);
                        await Task.Delay((int)Wait);

                    } break;
                case 1:
                    // Sortowanie przez wstawianie 
                    for (int i = 1; i < elementy.Count; i++)
                    {
                        int j = i;
                        while (j > 0 && elementy[j].CompareTo(elementy[j - 1]) < 0)
                        {
                            Swap(elementy, j, j - 1);

                            SwapRectangle((Rectangle)canv.Children[j], (Rectangle)canv.Children[j - 1]);
                            await Task.Delay((int)Wait);
                            j--;

                        }
                    } break;
                case 2:
                    // Sortowanie bąbelkowe
                    for (int i = 0; i < elementy.Count; i++)
                    {
                        bool isAnyChange = false;
                        for (int j = 0; j < elementy.Count - 1; j++)
                        {
                            if (elementy[j].CompareTo(elementy[j + 1]) > 0)
                            {
                                isAnyChange = true;
                                Swap(elementy, j, j + 1);
                                SwapRectangle((Rectangle)canv.Children[j], (Rectangle)canv.Children[j + 1]);
                                await Task.Delay((int)Wait);
                            }

                        }
                        if (!isAnyChange)
                        {
                            break;
                        }

                    } break;
                case 3:
                    // Sortowanie szybkie 
                    QuickSort(elementy, 0, elementy.Count - 1, canv);
                    
                    break;


            }
        }
        public async static void QuickSort(List<int> array, int left, int right, Canvas canvas)
        {
            var k = left;
            var l = right;
            var pivot = array[ (left+right)/2];
            while (k < l)
            {

                while (array[k] < pivot)
                    k++;
                while (array[l] > pivot)
                    l--;
                if (k <= l)
                {
                    // swap
                    
                    var tmp = array[k];
                    Rectangle temp = DrawRectangle(array[k]/ 2, canvas.ActualWidth / array.Count);
                    
                    
                    ChangeRectangle((Rectangle)canvas.Children[k], (Rectangle)canvas.Children[l]);
                    array[k++] = array[l];// ++ and -- inside array braces for shorter code


                    ChangeRectangle((Rectangle)canvas.Children[l], temp);
                    array[l--] = tmp;
                    await Task<int>.Delay((int)Wait);
                }

            }
            if (left < l)
                QuickSort(array, left, l, canvas);
            if (k < right)
                QuickSort(array, k, right, canvas);

            
        }


        public static void ChangeRectangle(Rectangle rect, Rectangle rect2)
        {
            rect.Height = rect2.Height;
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            elementy.Clear();
            canv.Children.Clear();
            Button.IsEnabled = true;
        }
        public static double Wait=1;
        
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            Wait=Slider.Value;
             
                
        }

        private void Slider_elementy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Wielkosc = Slider_elementy.Value;
        }
    }



    }



    

  

