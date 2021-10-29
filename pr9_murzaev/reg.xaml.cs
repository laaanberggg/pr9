using System;
using System.Collections.Generic;
using System.IO;
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

namespace pr9_murzaev
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class reg : Page
    {
        string path = "Users.csv";
        int id = 1;
        public reg()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(Convert.ToString(id) + ";");
                sw.Write(tbName.Text + ";");
                sw.Write(tbLog.Text + ";");
                sw.Write(tbPass.Password + "\n");
                id++;
            }
            MessageBox.Show("Регистрация успешна!", "Регистрация");
            frame.mainFrame.Navigate(new privet());
        }

        private void cancelreg_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new unknow());
        }
    }
}
