using ArchaeologicalSiteManagement.Services;
using ArchaeologicalSiteManagement.ViewModels;
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

namespace ArchaeologicalSiteManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            var siteRepository = new SiteRepository();
            var excRepository = new ExcavationRepository();
            var persistenceService = new PersistenceService();

            _viewModel = new MainViewModel(siteRepository, excRepository, persistenceService);
            DataContext = _viewModel;
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Undo();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Redo();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveData();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadData();
        }

        private void AddSite_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddSite(_viewModel.FormSite);
        }

        private void EditSite_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedSite == null) return;

            _viewModel.FormSite.Id = _viewModel.SelectedSite.Id;
            _viewModel.UpdateSite(_viewModel.SelectedSite, _viewModel.FormSite);
        }

        private void DeleteSite_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedSite == null) return;
            _viewModel.DeleteSite(_viewModel.SelectedSite);
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddRecord(_viewModel.FormRecord);
        }

        private void EditRecord_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedRecord == null) return;

            _viewModel.FormRecord.Id = _viewModel.SelectedRecord.Id;
            _viewModel.UpdateRecord(_viewModel.FormRecord);
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedRecord == null) return;
            _viewModel.DeleteRecord(_viewModel.SelectedRecord.Id);
        }
    }
}