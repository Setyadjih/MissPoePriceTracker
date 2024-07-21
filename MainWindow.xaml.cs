using Microsoft.EntityFrameworkCore;
using MissPoeAnalysis.Core;
using MissPoeAnalysis.Core.Models;
using MissPoeAnalysis.Core.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MissPoeAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Analyzer _analyzer = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Testing here");
            string fp = "D:\\repos\\MissPoeAnalysis\\TestData\\Pembelian 2024.xlsx";
            _analyzer.LoadBook(fp);

            Debug.WriteLine("Checking Items");
            _analyzer.GetItems();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _analyzer.Dispose();
            base.OnClosing(e);
        }
    }
}