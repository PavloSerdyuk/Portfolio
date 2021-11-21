using Koval_Bank_And_Branches.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koval_Bank_And_Branches.ViewModel
{
    class DataViewModel: ViewModelBase
    {
        private string _visibleControl = "User";

        public string VisibleControl
        {
            get => _visibleControl;
            set
            {
                _visibleControl = value;
                OnPropertyChange("VisibleControl");
            }
        }

        public DataViewModel()
        {
            SetControlVisibility = new Command(ControlVisibility);
        }

        public ICommand SetControlVisibility { get; set; }

        public void ControlVisibility(object args)
        {
            VisibleControl = args.ToString();
        }

        private ObservableCollection<PersonViewModel> _users { get; set; }
        
        public ObservableCollection<PersonViewModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChange("Users");
            }
        }
        private ObservableCollection<ContractViewModel> _contracts { get; set; }

        public ObservableCollection<ContractViewModel> Contracts 
        {
            get => _contracts;
            set
            {
                _contracts = value;
                OnPropertyChange("Contracts");
            }
        }
    }
}
