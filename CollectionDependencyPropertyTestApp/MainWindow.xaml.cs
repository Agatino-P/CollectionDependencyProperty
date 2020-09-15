using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectionDependencyPropertyTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Random _random = new Random();

        public ObservableCollection<string> Strings
        {
            get { return (ObservableCollection<string>)GetValue(StringsProperty); }
            set { SetValue(StringsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Strings.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StringsProperty =
            DependencyProperty.Register("Strings", typeof(ObservableCollection<string>), typeof(MainWindow), new PropertyMetadata(null));


        public MainWindow()
        {
            Strings = new ObservableCollection<string>();
            InitializeComponent();
        }

        private void btnStrings_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> newStrings = new ObservableCollection<string>();
            int numStrings = _random.Next(1, 10);
            for (int i = 1; i <= numStrings; i++)
            {
                newStrings.Add($"@{i}: {DateTime.Now}");
            }
            lister.Strings = newStrings;
        }
    }
}
