using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyFirstPrismApp.ViewModels.Models;
using Xamarin.Forms;

namespace MyFirstPrismApp.Droid
{
    [Activity(Label = "BlueActivity", Theme = "@android:style/Theme.NoDisplay", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class BlueActivity : Activity
    {
        public static BlueActivity bInstance;
       
        public List<BlueTooth> bListToSend = new List<BlueTooth>();
        
        MyBroadcastReceiver mReceiver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            BluetoothAdapter mBluetoothAdapter;
            base.OnCreate(savedInstanceState);
            
           
            bInstance = this;
            mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
           
            IntentFilter filter = new IntentFilter(BluetoothDevice.ActionFound);
            mReceiver = new MyBroadcastReceiver();
            IntentFilter filterF = new IntentFilter(BluetoothAdapter.ActionDiscoveryFinished);
            IntentFilter filterS = new IntentFilter(BluetoothAdapter.ActionDiscoveryStarted);
            RegisterReceiver(mReceiver, filter);
            RegisterReceiver(mReceiver, filterF);
            RegisterReceiver(mReceiver, filterS);

            StartAsyncDisc(mBluetoothAdapter);
            
           
           
            
        }
        protected override void OnDestroy()
        {
            
            base.OnDestroy();
            UnregisterReceiver(mReceiver);
        }
        private   AsyncTask StartAsyncDisc(BluetoothAdapter mBluetoothAdapter)
        {
            mBluetoothAdapter.StartDiscovery();
           
            return null;
            
        }
        public class MyBroadcastReceiver : BroadcastReceiver
        {
            public string blaa = "";
            public override void OnReceive(Context context, Intent intent)
            {
                List<String> StringToSend=new List<string>();
                List<BlueTooth> ListToSend = new List<BlueTooth>();
                
                string action = intent.Action;
                if (BluetoothDevice.ActionFound.Equals(action))
                {
                    BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                    String deviceName = device.Name;
                    String deviceHardwareAddress = device.Address; // MAC address

                    BlueTooth btnew = new BlueTooth();
                    btnew.DeviceName = deviceName;
                    btnew.MacAddr = deviceHardwareAddress;
                    bInstance.bListToSend.Add(btnew);
                    System.Diagnostics.Debug.WriteLine("Found Device: " + deviceName);

                    
                  
                    
                }
                else if (BluetoothAdapter.ActionDiscoveryStarted.Equals(action))
                {
                    System.Diagnostics.Debug.WriteLine("BT Discovery Started");
                    
                    StringToSend= new List<string>();
                    bInstance.bListToSend = new List<BlueTooth>();

                }
                else if (BluetoothAdapter.ActionDiscoveryFinished.Equals(action))
                {
                    System.Diagnostics.Debug.WriteLine("BT Discovery Finished");
                   
                    for (int i = 0; i < bInstance.bListToSend.Count; i++)
                        StringToSend.Add(bInstance.bListToSend[i].DeviceName + "   " + bInstance.bListToSend[i].MacAddr);
                   
                    Views.MainPage.staticList.ItemsSource = StringToSend;
                    BlueTooth.staticBlueList =new List<BlueTooth>( bInstance.bListToSend);
                    ViewModels.MainPageViewModel.isUpdatedList = true;
                    Views.MainPage.staticLabel.Text = "Scanning Finished";
                        
                    
                    bInstance.Finish();
                     

                }
            }

        }
    }
}