using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        public Details(TransactionDataShort transactionDataShort)
        {

            InitializeComponent();

            string crypto = transactionDataShort.Type;
            string coin = transactionDataShort.Coins;
            string currency = transactionDataShort.GetAdditionalData().Currency;

            To.Text = transactionDataShort.To;
            Address.Text = transactionDataShort.GetAdditionalData().Address;
            Currency.Text = transactionDataShort.GetAdditionalData().Currency;
            W.Text = currency + '|' + coin + '|' + crypto;
            TransactionFee.Text = currency + '|' + transactionDataShort.GetAdditionalData().TransactionFee + '|' + crypto;
            Status.Text = transactionDataShort.GetAdditionalData().Status;

            Header.Text = "Transaction Details - " + crypto;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}