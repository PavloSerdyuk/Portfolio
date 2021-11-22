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

        public ViewModelBase SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChange("SelectedItem");
            }
        }

        private ViewModelBase _selectedItem;

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
            BindDeleteItem = new Command(DeleteItem);
        }

        public ICommand SetControlVisibility { get; set; }
        public ICommand BindDeleteItem { get; set; }

        public void DeleteItem(object args)
        {
            try
            {
                if (_visibleControl == "Contract" && _selectedItem != null)
                {
                    Contracts.Remove(Contracts.Where(item => item.Id == (_selectedItem as ContractViewModel).Id).FirstOrDefault());
                }
                else if (_visibleControl == "User" && _selectedItem != null)
                {
                    Users.Remove(Users.Where(item => item.Id == (_selectedItem as PersonViewModel).Id).FirstOrDefault());
                }
                else
                {
                    string messageBoxText = "Select item to delete it!";
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
            catch (Exception exc)
            {
                string messageBoxText = exc.Message;
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }
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
