using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;

namespace MyFirstPrismApp.ViewModels.Models
{
    public class BlueTooth : BindableBase
    {
        
        public static List<BlueTooth> staticBlueList=new List<BlueTooth>();
        public string DeviceName
        {
            get; //{ return _deviceName; }
            set;//{ SetProperty(ref _deviceName, value); }
        }

        
        public string MacAddr
        {
            get; //{ return _macAddr; }
            set; //{ SetProperty(ref _macAddr, value); }
        }
        public BlueTooth()
        {

        }

        public interface IStartBT
        {
            void ScanBT();
        }
    }
}
