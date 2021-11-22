using Koval_Bank_And_Branches.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koval_Bank_And_Branches.ViewModel
{
    class ContractViewModel : ViewModelBase
    {
        private Guid _userId;

        public Guid UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChange("UserId");
            }
        }

        private decimal _amount;

        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChange("Amount");
            }
        }

        private double _procentIncreasement;

        public double ProcentIncreasement
        {
            get => _procentIncreasement;
            set
            {
                _procentIncreasement = value;
                OnPropertyChange("ProcentIncreasement");
            }
        }

        private ContractType _contractType;
        public ContractType ContractType 
        {
            get => _contractType;
            set
            {
                _contractType = value;
                OnPropertyChange("ContractType");
            }
        }

        private Guid _managerId;

        public Guid ManagerId
        {
            get => _managerId;
            set
            {
                _managerId = value;
                OnPropertyChange("ManagerId");
            }
        }

        private DateTime _createdAt;

        public DateTime CreatedAt
        {
            get => _createdAt;
            set
            {
                _createdAt = value;
                OnPropertyChange("CreatedAt");
            }
        }

        private DateTime _validUntil;

        public DateTime ValidUntil
        {
            get => _validUntil;
            set
            {
                _validUntil = value;
                OnPropertyChange("ValidUntil");
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
    }
}
