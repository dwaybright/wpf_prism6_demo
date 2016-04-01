using System.Windows;
using System.Reflection;


namespace message.Views
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            typeof(System.Windows.Controls.Primitives.ButtonBase)
                .GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(LoadMessageBoard, new object[0]);
        }
    }
}
