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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Data.SqlClient;



namespace table_sql_data_17_03_2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sqlSourse = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=library;" +
"Integrated Security=true;";
        SqlConnection connections;
        SqlDataAdapter adapter;
        DataTable data;
        
        public MainWindow()
        {
            InitializeComponent();
            connections= new SqlConnection(sqlSourse);
        }

        private void fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string select = textB.Text;
                adapter = new SqlDataAdapter(select, connections);
                Table.DataContext = null;
                SqlCommandBuilder cm = new SqlCommandBuilder(adapter);
                data = new DataTable();
                adapter.Fill(data);
                Table.DataContext = data.DefaultView;
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
           
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(data);
        }
    }
}
