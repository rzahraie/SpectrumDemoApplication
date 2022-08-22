using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        DataRepository dataRepository;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Header.Focus();
        }
        public Page1()
        {
            InitializeComponent();

            dataRepository = new DataRepository();
            dataGrid.ItemsSource = dataRepository.TransactionDataCollectionShort;

            dataRepository.filtertextchanged = OnFilterChanged;
        }

        private async void dataGrid_GridTapped(object sender, Syncfusion.SfDataGrid.XForms.GridTappedEventArgs e)
        {
            TransactionDataShort transactionDataShort = e.RowData as TransactionDataShort;
            await Navigation.PushAsync(new Details(transactionDataShort));
        }

        void OnFilterChanged()
        {
            if (dataGrid.View != null)
            {
                this.dataGrid.View.Filter = dataRepository.FilterRecords;
                this.dataGrid.View.RefreshFilter();
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataRepository.FilterText = (sender as SearchBar).Text;

        }
    }
}