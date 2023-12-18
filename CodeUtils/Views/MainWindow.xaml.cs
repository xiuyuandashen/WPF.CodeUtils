using System.Windows;

namespace CodeUtils.Views
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

        private void MenuBar_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DrawerLeft.IsOpen = false;
        }
    }
}
