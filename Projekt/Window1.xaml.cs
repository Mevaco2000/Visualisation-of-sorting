using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            double[] dataX = MainWindow.listaT.Select(x=>(double)x).ToArray();
            double[] dataY = MainWindow.lista.Select(y=>(double)y).ToArray();
            

            double[] dataXIS = MainWindow.listaTIS.Select(x1 => (double)x1).ToArray();
            double[] dataYIS = MainWindow.listaIS.Select(y1 => (double)y1).ToArray();

            double[] dataXBS = MainWindow.listaTBS.Select(x11 => (double)x11).ToArray();
            double[] dataYBS = MainWindow.listaBS.Select(y11 => (double)y11).ToArray();

            double[] dataXQS = MainWindow.listaTQS.Select(x111 => (double)x111).ToArray();
            double[] dataYQS = MainWindow.listaQS.Select(y111 => (double)y111).ToArray();
            Wykres1.Plot.AddScatter(dataX, dataY,label:"Selection Sort");
            Wykres1.Plot.AddScatter(dataXIS, dataYIS,label: "Insertion Sort");
            Wykres1.Plot.AddScatter(dataXBS, dataYBS,label: "Bubble Sort");
            Wykres1.Plot.AddScatter(dataXQS, dataYQS, label: "Quick Sort");
            Wykres1.Plot.XLabel("Czas [ms]");
            Wykres1.Plot.YLabel("Ilosc posortowanych elementow");
            Wykres1.Plot.Legend();
            Wykres1.Refresh();

        }
    }
}
