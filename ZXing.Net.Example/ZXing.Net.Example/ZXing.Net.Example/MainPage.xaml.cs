using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace ZXing.Net.Example
{
    public partial class MainPage : ContentPage
    {
        private ZXingScannerPage _scanPage;

        public MainPage()
        {
            InitializeComponent();
            _scanPage = new ZXingScannerPage
                        {
                            DefaultOverlayBottomText = "", DefaultOverlayTopText = "線をバーコードに合わせてください。",
                        };
            _scanPage.OnScanResult += ScanPageOn_OnScanResult;
        }

        private async void ScanButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(_scanPage);
        }

        private void ScanPageOn_OnScanResult(Result result)
        {
            // スキャン停止
            _scanPage.IsScanning = false;

            Device.BeginInvokeOnMainThread(async () =>
                                           {
                                               await Navigation.PopModalAsync();
                                               await DisplayAlert("Scanned Barcode", result.Text, "OK");
                                           });
        }
    }
}