using System.Windows;

namespace LabWork45
{
    /// <summary>
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void SendSQLiteCommandButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object result = SQLite.DataAccessLayer.GetScalarValue(SQLiteCommandTextBox.Text);
                if (result is null)
                    result = "NULL";
                MessageBox.Show(result.ToString(),"Результат",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректная команда",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void SendMSSQLCommandButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object result = MSSQL.DataAccessLayer.GetScalarValue(MSSQLCommandTextBox.Text);
                if (result is null)
                    result = "NULL";
                MessageBox.Show(result.ToString(),
                                "Результат",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректная команда или не удалось установить подключение",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }

        }
    }
}
