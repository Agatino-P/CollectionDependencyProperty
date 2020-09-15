using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CollectionDependencyPropertyTestApp
{
    /// <summary>
    /// Interaction logic for Lister.xaml
    /// </summary>
    public partial class Lister : UserControl
    {


        public ObservableCollection<string> Strings
        {
            get { return (ObservableCollection<string>)GetValue(StringsProperty); }
            set { SetValue(StringsProperty, value); }
        }
        public static readonly DependencyProperty StringsProperty =
              DependencyProperty.Register("Strings", typeof(ObservableCollection<string>), typeof(Lister), new PropertyMetadata(null, onStringsPropertyChange));

        private static void onStringsPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Lister lister))
            {
                return;
            }

            lister.displayStrings();
        }


        public Lister()
        {
            Strings = new ObservableCollection<string>();
            InitializeComponent();
        }

        private void displayStrings()
        {
            if (Strings == null)
            {
                return;
            }

            if (tbLog != null)
            {

                tbLog.Text = string.Empty;
                foreach (string s in Strings)
                {
                    tbLog.Text += s + @"\n";
                }
            }
        }

    }
}
