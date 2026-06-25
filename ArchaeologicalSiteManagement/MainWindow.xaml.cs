using ArchaeologicalSiteManagement.Models;
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

        private void SimulateNext_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedRecord == null)
            {
                MessageBox.Show("Please select a record.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _viewModel.SimulateNext();
        }

        private void AddSite_Click(object sender, RoutedEventArgs e)
        {
            if (!_viewModel.ValidateSite(_viewModel.FormSite))
            {
                MessageBox.Show("Molimo unesite ispravne vrednosti.", "Validacija", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _viewModel.FormSite.Id = Guid.Empty;
            _viewModel.AddSite(_viewModel.FormSite);
        }

        private void EditSite_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedSite == null) return;
            _viewModel.FormSite = new ArchaeologicalSite
            {
                Id = _viewModel.SelectedSite.Id,
                Name = _viewModel.SelectedSite.Name,
                Location = _viewModel.SelectedSite.Location,
                Civilization = _viewModel.SelectedSite.Civilization,
                DiscoveryYear = _viewModel.SelectedSite.DiscoveryYear,
                SiteType = _viewModel.SelectedSite.SiteType
            };
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

            _viewModel.FormRecord = new ExcavationRecord
            {
                Id = _viewModel.SelectedRecord.Id,
                SiteId = _viewModel.SelectedRecord.SiteId,
                ExcavationDate = _viewModel.SelectedRecord.ExcavationDate,
                AreaExcavatedM2 = _viewModel.SelectedRecord.AreaExcavatedM2,
                ArtifactsFound = _viewModel.SelectedRecord.ArtifactsFound,
                DepthReachedCm = _viewModel.SelectedRecord.DepthReachedCm,
                State = _viewModel.SelectedRecord.State
            };
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedRecord == null) return;
            _viewModel.DeleteRecord(_viewModel.SelectedRecord.Id);
        }
    }
}