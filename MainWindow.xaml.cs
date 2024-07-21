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
        private readonly DBContext _context = new();
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Creating New DB");
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Items.Load();

            Debug.WriteLine("Testing here");
            string fp = "D:\\repos\\MissPoeAnalysis\\TestData\\Pembelian 2024.xlsx";
            var foob = new Analyzer(fp, _context);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Debug.WriteLine("Checking Item");
            var items = _context.Items.Where(i => i.Vendor == "Tiara");
            foreach (var item in items)
            {
                Debug.WriteLine($"{item.Name}, {item.Vendor}, {item.Price}, {item.Date}");
            }

            Debug.WriteLine("Tear down DB");
            _context.Database.EnsureDeleted();
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}