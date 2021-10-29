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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class vhod : Page
    {
        string path = "Users.csv";
        List<polz> Users = new List<polz>();
        public vhod()
        {
            InitializeComponent();
        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string[] sArr = sr.ReadLine().Split(';');
                    Users.Add(new polz() { id = sArr[0], name = sArr[1], log = sArr[2], parol = sArr[3] });
                }
            }
            polz User = Users.FirstOrDefault(x => x.log == tbLogin.Text && x.parol == tbParol.Password);
            if (User != null)
            {
                frame.mainFrame.Navigate(new privet());
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Авторизация");
                switch (MessageBox.Show("Хотите зарегистрироваться?\nНажмите Отмена, чтобы повторить ввод", "Регистрация", MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Yes:
                        frame.mainFrame.Navigate(new reg());
                        break;
                    case MessageBoxResult.No:
                        frame.mainFrame.Navigate(new unknow());
                        break;
                    case MessageBoxResult.Cancel:
                        frame.mainFrame.Navigate(new vhod());
                        break;
                }

            }
        }

        private void vozvrat_Click(object sender, RoutedEventArgs e)
        {
            frame.mainFrame.Navigate(new unknow());
        }
    }
}
