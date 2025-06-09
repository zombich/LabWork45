using LabWork45;
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

namespace LabWork45
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateConnectionStringButton_Click(object sender, RoutedEventArgs e)
        {
            MSSQLConnectionStringTextBox.Text = MSSQL.DataAccessLayer.ConnectionString;
            SQLiteConnectionStringTextBox.Text = SQLite.DataAccessLayer.ConnectionString;
        }

        private void SendMSSQLCommandButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendSQLiteCommandButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}