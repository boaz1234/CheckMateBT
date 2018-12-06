using MyFirstPrismApp.ViewModels;
using MyFirstPrismApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


using Prism.Commands;

namespace MyFirstPrismApp.Views
{
    public partial class MainPage : ContentPage
    {
        public static List<String> BlueToothList { get; set; }
        public ObservableCollection<BlueTooth> BlueToothList2 { get; set; }
        public static ListView staticList;
        public static Label staticLabel;
       
        //public IAdapter adapter;
        
       // ObservableCollection<IDevice> deviceList;
        private const string Uuid = "00001101-0000-1000-8000-00805F9B34FE";
        //Guid x = new Guid(Uuid);
        public DelegateCommand LoadBlueToothCmd { get; set; }

        public static void UpdateList(List<string> inList)
        {
            staticList.ItemsSource = inList;
        }

        public MainPage()
        {
           
           // LoadBlueToothCmd = new DelegateCommand(DisplayAlertMy);
            InitializeComponent();
            //BindingContext = new ListViewViewModel();
            //BlueToothList = new List<string>()
            //{
            //    BlueToothList2[0].DeviceName +"\n"+  BlueToothList2[0].MacAddr,
                
            //    BlueToothList2[1].DeviceName +"\n"+  BlueToothList2[1].MacAddr,
            //     BlueToothList2[2].DeviceName +"\n"+  BlueToothList2[2].MacAddr,
            //      BlueToothList2[3].DeviceName +"\n"+  BlueToothList2[3].MacAddr

            //};
            // MyList.ItemsSource = BlueToothList;
            MyList.ItemsSource = new List<string>();
            staticList = MyList;
            staticLabel = MyLabel;
            //MessagingCenter.Subscribe<List<String>>(this, "AddDevice", (list) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("List Update MessagingCenter");
            //    MyList.ItemsSource = list;
            //});
            //  Device.BeginInvokeOnMainThread(async () => { await DisplayAlert("Alert", "No internet connection", "Ok"); });
            // BindingContext = new ListViewViewModel(); 

           // Task.Run(() => { });



        }

        public void DisplayAlertMy()
        {
            DisplayAlert("BT", "good bye world","OK");
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;


            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)

        {
            String temp;
            //staticLabel.Text 
            temp= e.SelectedItem.ToString();
            for(int i=0;i<BlueTooth.staticBlueList.Count;i++)
            {
                if (temp.Contains(BlueTooth.staticBlueList[i].DeviceName))
                    staticLabel.Text = BlueTooth.staticBlueList[i].DeviceName;
            }

        }

    }
}