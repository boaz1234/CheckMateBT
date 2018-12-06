using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using MyFirstPrismApp.Droid;
using Xamarin.Forms;
using static MyFirstPrismApp.ViewModels.Models.BlueTooth;

[assembly: Xamarin.Forms.Dependency(typeof(Message))]
[assembly: Dependency(typeof(IStartBTImpl))]
namespace MyFirstPrismApp.Droid
{
    public class IStartBTImpl : IStartBT
    {
        public void ScanBT()
        {

            
            var intent = new Intent(Android.App.Application.Context, typeof(BlueActivity));
            intent.AddFlags(ActivityFlags.NewTask);
             Android.App.Application.Context.StartActivity(intent);
        }
    }
}