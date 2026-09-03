using Avalonia.Controls;
using Buildershop.Context;
using System.Linq;

namespace Buildershop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Demka24Context context = new Demka24Context();

            var user = context.Users.FirstOrDefault(x => x.Login == LoginBox.Text && x.Password == PasswordBox.Text);

            if (user != null)
            {
                SaveUser._user = user;
                Glavnoe glavnoe = new Glavnoe();
                glavnoe.Show();
                this.Close();
            }

            else
            {
                durak.IsVisible = true;
            }
        }

        private void Guest_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Demka24Context context = new Demka24Context();

            var user = context.Users.FirstOrDefault(x=>x.Login == "4" && x.Password == "4");
            SaveUser._user = user;
            Glavnoe glavnoe = new Glavnoe();
            glavnoe.Show();
            this.Close();
        }
    
    }
}