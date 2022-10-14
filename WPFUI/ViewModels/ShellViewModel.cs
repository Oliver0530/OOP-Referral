using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    //Screen gives better control if a form has been updated but not saved for example. 
    public class ShellViewModel : Conductor<object>
    {
        //Dont manipulate directually, instead the public property
        private string _HWType = "CPU";
        private string _lastName;
        private BindableCollection<HardwareModel> _HardwareTypes = new BindableCollection<HardwareModel>();
        private HardwareModel _SelectedHardware;

        private BindableCollection<RamModel> _RamTypes = new BindableCollection<RamModel>();
        private RamModel _SelectedRam;

        private BindableCollection<RamModel> _RamPrice = new BindableCollection<RamModel>();

        private BindableCollection<HardwareModel> _HWPrice = new BindableCollection<HardwareModel>();



        public ShellViewModel()
        {
            HardwareTypes.Add(new HardwareModel { HardwareType = "RTX 3090", HWPrice = 10.0 });
            HardwareTypes.Add(new HardwareModel { HardwareType = "RTX 3080", HWPrice = 5.0 });
            HardwareTypes.Add(new HardwareModel { HardwareType = "RTX 3070ti", HWPrice = 15.0 });

            RamTypes.Add(new RamModel { RamType = "15GB", RamPrice = 10.0 });
            RamTypes.Add(new RamModel { RamType = "30GB", RamPrice = 20.0 });
            RamTypes.Add(new RamModel { RamType = "64GB", RamPrice = 30.0 });
        }

        public string HWType
        {
            get
            {
                return _HWType;
            }
            set
            {
                _HWType = value;
                // The property will be changed when the TextBox contains a different value. This means the value is not fixed anymore.
                NotifyOfPropertyChange(() => HWType);
                NotifyOfPropertyChange(() => FullName);

            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{HWType} {LastName}"; }
        }

        // Normally called a list but in MVVM its called a BindableCollection
        public BindableCollection<HardwareModel> HardwareTypes
        {
            get
            {
                return _HardwareTypes;
            }
            set
            {
                _HardwareTypes = value;
            }
        }

        public BindableCollection<HardwareModel> HWPrice
        {
            get
            {
                return _HWPrice;
            }
            set
            {
                _HWPrice = value;
            }
        }


        // Selected Hardware model
        public HardwareModel SelectedHardware
        {
            get
            {
                return _SelectedHardware;
            }
            set
            {
                _SelectedHardware = value; NotifyOfPropertyChange(() => SelectedHardware);
            }
        }

        //RamModel - START 
        public BindableCollection<RamModel> RamTypes
        {
            get
            {
                return _RamTypes;
            }
            set
            {
                _RamTypes = value;
            }
        }
        //Ram Price
        public BindableCollection<RamModel> RamPrice
        {
            get
            {
                return _RamPrice;
            }
            set
            {
                _RamPrice = value;
            }
        }

        // Selected person model
        public RamModel SelectedRam
        {
            get
            {
                return _SelectedRam;
            }
            set
            {
                _SelectedRam = value; NotifyOfPropertyChange(() => SelectedRam);
            }
        }
        //RamModel - END

        public bool CanClearText(string firstName, string lastName)
        {
            //return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName, string lastName)
        {
            HWType = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            //ActivateItem();
        }
    }     
}
