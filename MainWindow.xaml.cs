using Microsoft.EntityFrameworkCore;
using MissPoeAnalysis.Core;
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
        private readonly DBContext _context = new DBContext();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Items.Load();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}