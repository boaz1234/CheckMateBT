using MyFirstPrismApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static MyFirstPrismApp.ViewModels.Models.BlueTooth;

namespace MyFirstPrismApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public static bool isUpdatedList = false;
        public DelegateCommand NavigateToSpeakPageCommand { get; private set; }
        public DelegateCommand StartScanBluetoothCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "CheckMate BT App";
            _navigationService = navigationService;
            
            StartScanBluetoothCommand = new DelegateCommand(StartScanBluetooth);
            //Task.Run(() => {
            //    List<String> StringToDisp = new List<String>();
            //    while(true)
            //    {
            //        if(isUpdatedList)
            //        {
            //            System.Diagnostics.Debug.WriteLine("List Updated From PCL");
            //            System.Diagnostics.Debug.WriteLine(staticBlueList[0].DeviceName);
            //            isUpdatedList = false;
            //            for (int i = 0; i < staticBlueList.Count; i++)
            //                StringToDisp.Add(staticBlueList[i].DeviceName + "   " + staticBlueList[i].MacAddr);
            //            //Application.Current.
            //            MainPage.UpdateList(StringToDisp);
            //            //Views.MainPage.UpdateList(StringToDisp);
            //            //Views.MainPage.staticList.ItemsSource = StringToSend;
            //            //DoUpdatingViewList Stuff

            //        }
            //    }
            //});
        }

     

        private void StartScanBluetooth()
        {
            //_navigationService.Navigate("SpeakPage"); //probably deprecated
            //_navigationService.NavigateAsync("SpeakPage");
            MainPage.staticLabel.Text = "Scanning for BT Devices... Please wait";
            DependencyService.Get<IStartBT>().ScanBT();

        }
    }
}
