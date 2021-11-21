using AutoMapper;
using Koval_Bank_And_Branches.Model;
using Koval_Bank_And_Branches.ViewModel;

namespace Koval_Bank_And_Branches.Profiles
{
    class DataModelProfile: Profile
    {
        public DataModelProfile()
        {
            CreateMap<DataModel, DataViewModel>();
            CreateMap<DataViewModel, DataModel> ();

            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonViewModel, Person>();

            CreateMap<Contract, ContractViewModel>();
            CreateMap<ContractViewModel, Contract>();
        }
    }
}
