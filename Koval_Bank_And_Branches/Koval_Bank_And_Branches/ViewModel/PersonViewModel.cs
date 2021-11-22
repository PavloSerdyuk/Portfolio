using Koval_Bank_And_Branches.Enums;
using Koval_Bank_And_Branches.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koval_Bank_And_Branches.ViewModel
{
    class PersonViewModel: ViewModelBase
    {

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChange("Name");
            }
        }

        private string _surname;

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChange("Surname");
            }
        }

        private Guid _id;

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChange("Id");
            }
        }

        private Role _userRole;
        public Role UserRole
        {
            get => _userRole;
            set
            {
                _userRole = value;
                OnPropertyChange("UserRole");
            }
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {UserRole.ToString()}";
        }
    }
}
