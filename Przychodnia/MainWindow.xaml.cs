using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Przychodnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PrzychodniaEntities db = new PrzychodniaEntities();

            avaibleDataGrid.ItemsSource = db.Lekarzes.ToList();
            cityComboBox.ItemsSource = db.Lekarzes.Select(c => c.Miasto).Distinct().ToList();
            specComboBox.ItemsSource = db.Lekarzes.Select(s => s.Specjalizacja).Distinct().ToList();
        }



        private void searchDoctor_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();

            
            cityComboBox.SelectedItem = null;
            specComboBox.SelectedItem = null;
            placowkaComboBox.SelectedItem = null;
            avaibleDataGrid.ItemsSource = db.Lekarzes.ToList();
        }


        private void specComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();
            avaibleDataGrid.ItemsSource = db.Lekarzes.Where(x => x.Specjalizacja == specComboBox.SelectedItem).ToList();
            placowkaComboBox.ItemsSource = db.Lekarzes.Where(x => x.Miasto == cityComboBox.SelectedItem && x.Specjalizacja == specComboBox.SelectedItem).Select(p => p.Placówka).Distinct().ToList();
        }



        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();
            if (cityComboBox.SelectedItem != null)
            {
                placowkaComboBox.IsEnabled = true;
                placowkaComboBox.ItemsSource = db.Lekarzes.Where(x => x.Miasto == cityComboBox.SelectedItem).Select(p => p.Placówka).Distinct().ToList();
                avaibleDataGrid.ItemsSource = db.Lekarzes.Where(x => x.Miasto == cityComboBox.SelectedItem).ToList();
            }
   
            specComboBox.ItemsSource = db.Lekarzes.Where(x => x.Miasto == cityComboBox.SelectedItem).Select(s => s.Specjalizacja).Distinct().ToList();
        }


        private void peselTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nameTextBox.Text != null && surrnameTextBox.Text != null && phoneTextBox.Text != null && peselTextBox.Text != null)
            {
                
                if (peselTextBox.Text.Length == 11)
                {
                    if (phoneTextBox.Text.Length == 9)
                    {
                        saveButton.IsEnabled = true;
                    } else
                    {
                        saveButton.IsEnabled=false;
                    }
                    
                }
                else
                {
                    saveButton.IsEnabled = false;
                }

            }
            
        }

        private void phoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void placowkaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();
            avaibleDataGrid.ItemsSource = db.Lekarzes.Where(z => z.Miasto == cityComboBox.SelectedItem && z.Placówka == placowkaComboBox.SelectedItem).ToList();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();
            Logic logic = new Logic();

            logic.addPatient(nameTextBox.Text, surrnameTextBox.Text, phoneTextBox.Text, peselTextBox.Text, int.Parse(idLekarzTextBox.Text));
            nameTextBox.Text = null;
            surrnameTextBox.Text = null;
            phoneTextBox.Text = null;
            peselTextBox.Text = null;
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            loadDataGrid.Visibility = Visibility.Visible;
            Thread thread1 = new Thread(() => LoadVisits());

            thread1.Start();

            Thread orchestratorThread = new Thread(() =>
            {
                thread1.Join();

                Dispatcher.Invoke(() => loadDataGrid.Visibility = Visibility.Hidden);
            });
            orchestratorThread.Start();
        }
        private void LoadVisits()
        {
            PrzychodniaEntities db = new PrzychodniaEntities();

            Thread.Sleep(1500);

            Dispatcher.Invoke(() =>
            {
                wizytyDataGrid.ItemsSource = (from p in db.Pacjencis
                                              join w in db.Wizyties
                                              on p.ID_Pacjent equals w.ID_pacjent
                                              join l in db.Lekarzes
                                              on w.ID_lekarz equals l.ID_Lekarz
                                              select new
                                              {
                                                  Lekarz = l.Nazwisko,
                                                  Specjalizacja = l.Specjalizacja,
                                                  Imie_Pacjenta = p.Imie,
                                                  Nazwisko_Pacjenta = p.Nazwisko,
                                                  Pesel_Pacjenta = p.PESEL,
                                                  Placówka = l.Placówka,
                                                  Miasto = l.Miasto
                                              }).ToList();
            });
        }
    }
}
