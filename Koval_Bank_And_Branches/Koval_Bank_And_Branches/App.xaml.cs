using AutoMapper;
using Koval_Bank_And_Branches.Model;
using Koval_Bank_And_Branches.Profiles;
using Koval_Bank_And_Branches.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Koval_Bank_And_Branches
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DataModel _dataModel;
        private DataViewModel _dataViewModel;

        private readonly IMapper mapper;

        public App()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DataModelProfile());
            });

            mapper = mapperConfig.CreateMapper();

            _dataModel = DataModel.Load();

            _dataViewModel = mapper.Map<DataModel, DataViewModel>(_dataModel);

            #region Data Initialization
            /*_dataModel = new DataModel
            {
                Users = new List<Person>(5)
                {
                    new Person() {Name = "First",  Surname = "Tsrif", UserRole = Enums.Role.Customer, Id = Guid.NewGuid()},
                    new Person() {Name = "Second", Surname = "Dnoces", UserRole = Enums.Role.Customer, Id = Guid.NewGuid()},
                    new Person() {Name = "Third",  Surname = "Drith", UserRole = Enums.Role.Customer, Id = Guid.NewGuid()},
                    new Person() {Name = "Fourth",  Surname = "Htrouf", UserRole = Enums.Role.Customer, Id = Guid.NewGuid()},
                    new Person() {Name = "Fifth",  Surname = "Htfif", UserRole = Enums.Role.Customer, Id = Guid.NewGuid()},
                    new Person() {Name = "Manager",  Surname = "Main", UserRole = Enums.Role.Manager, Id = Guid.NewGuid()},
                    new Person() {Name = "Man", Surname = "Secondary", UserRole = Enums.Role.Manager, Id = Guid.NewGuid()}
                },
            };
            for (int i = 0; i < _dataModel.Users.Count; i++)
            {
                _dataModel.Contracts.Add(new Contract()
                {
                    ManagerId = _dataModel.Users.Where(item => item.UserRole == Enums.Role.Manager).ToList()[i % 2].Id,
                    UserId = _dataModel.Users.Where(item => item.UserRole == Enums.Role.Customer).ToList()[i%5].Id,
                    CreatedAt = DateTime.Now,
                    ValidUntil = DateTime.Now,
                    ContractType = (Enums.ContractType)(i % 3),
                    Amount = i * 100,
                    Id = Guid.NewGuid(),
                    ProcentIncreasement = (i%2)*3
                });
            }
            _dataModel.Save();
            */
            #endregion

            var mainWindow = new MainWindow() { DataContext = _dataViewModel };
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                _dataModel = mapper.Map<DataViewModel, DataModel>(_dataViewModel);
                _dataModel.Save();
            }
            catch (Exception)
            {
                base.OnExit(null);
                throw;
            }
        }
    }
}
