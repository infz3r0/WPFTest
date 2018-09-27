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

using System.Data.Entity;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WPFTestEntities1 db = new WPFTestEntities1();

        CollectionViewSource cityViewSource;
        CollectionViewSource personViewSource;

        public MainWindow()
        {
            InitializeComponent();
            cityViewSource = ((CollectionViewSource)(this.FindResource("cityViewSource")));
            personViewSource = ((CollectionViewSource)(this.FindResource("personViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cityViewSource.Source = db.cities.ToList();

            db.people.Load();
            personViewSource.Source = db.people.Local;
        }

        private void btnDeleteCity_Click(object sender, RoutedEventArgs e)
        {
            city o = (city)cityDataGrid.SelectedCells[0].Item;
            try
            {
                db.cities.Remove(o);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            cityViewSource.View.Refresh();
        }
    }
}
