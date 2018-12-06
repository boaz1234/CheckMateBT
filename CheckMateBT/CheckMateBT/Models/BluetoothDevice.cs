using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckMateBT.Models
{
    public class BlueTooth : BindableBase
    {
        private string _deviceName;
        public string DeviceName
        {
            get; //{ return _deviceName; }
            set;//{ SetProperty(ref _deviceName, value); }
        }

        private string _macAddr;
        public string MacAddr
        {
            get; //{ return _macAddr; }
            set; //{ SetProperty(ref _macAddr, value); }
        }
        public BlueTooth()
        {

        }
    }
}
