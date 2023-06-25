using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfResourceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<User> users = new ObservableCollection<User>()
        {
            new(){ Name = "Bob" },
            new(){ Name = "Tom" },
            new(){ Name = "Leo" },
            new(){ Name = "Joe" },
            new(){ Name = "Sam" },
        };
        public MainWindow()
        {
            InitializeComponent();
            LinearGradientBrush gradientGreen = new();
            gradientGreen.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 0), 0));
            gradientGreen.GradientStops.Add(new GradientStop(Colors.DarkGreen, 1));

            this.Resources.Add("gradientGreen", gradientGreen);

            this.Resources.Add("users", users);

            Button button = new Button();
            button.Content = "Click me";
            button.FontSize = 28;
            button.Background = this.TryFindResource("gradientGreen") as Brush;
            button.Background = Brushes.Aqua;
            button.Click += ButtonAddUser_Click;

            stack.Children.Add(button);
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new() { Name = "Sid" });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["solidRed"] = new SolidColorBrush(Colors.Yellow);
        }
    }
}
