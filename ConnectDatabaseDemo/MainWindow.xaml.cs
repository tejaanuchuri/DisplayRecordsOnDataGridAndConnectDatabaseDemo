using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConnectDatabaseDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadEmployeeRecordsOnGrid();
        }

        private void LoadEmployeeRecordsOnGrid()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "Select * from EmployeeTable";
            command.Connection = connection;
            OleDbDataReader rd = command.ExecuteReader();
            datagrid.ItemsSource = rd;
        }
    }
}
