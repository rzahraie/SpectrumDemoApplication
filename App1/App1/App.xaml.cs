using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzAwMTc3QDMyMzAyZTMyMmUzMG15ZzZqQlhXQ0g5VzM0cE1Pd0ZMdUFOaDNyS1pPdkZkamk0Vkt3RjFFV2c9");

            InitializeComponent();

            MainPage = new NavigationPage(new Page1());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
