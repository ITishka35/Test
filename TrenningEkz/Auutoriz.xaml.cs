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

namespace TrenningEkz
{
    /// <summary>
    /// Логика взаимодействия для Auutoriz.xaml
    /// </summary>
    public partial class Auutoriz : Page
    {
        public Auutoriz()
        {
            InitializeComponent();
            AppConnect.EKZ = new EkzamenDBEntities();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            var userr = AppConnect.EKZ.User.Where(p => p.Password == psb.Password && p.Login == Login.Text).FirstOrDefault();
            if(userr==null)
            {
                MessageBox.Show("Пользователь не найден");
            }
            else if (userr.Role.ID_Role == 1)
            {
                MessageBox.Show("Вы зашли как админ");
                AppFrame.frame.Navigate(new AllProdAdmin());
            }
            else if (userr.Role.ID_Role == 2)
            {
                MessageBox.Show("Вы зашли как менеджер");
                AppFrame.frame.Navigate(new ManagerAllProdList());
            }
            else if (userr.Role.ID_Role == 3)
            {
                MessageBox.Show("Вы зашли как клиент");
                AppFrame.frame.Navigate(new ClientAllProdLIst());
            }
        }

        private void SignInGost_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frame.Navigate(new GostPage());
        }
    }
}
