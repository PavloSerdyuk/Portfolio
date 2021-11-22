using Koval_Bank_And_Branches.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koval_Bank_And_Branches.Model
{
    [Serializable]
    class DataModel
    {
        public List<Person> Users { get; set; }
        public List<Contract> Contracts { get; set; }

        public DataModel()
        {
            Users = new List<Person>();
            Contracts = new List<Contract>();
        }

        public static readonly string DataPath = "info.dat";

        public static DataModel Load() =>
            File.Exists(DataPath) ? DataSerializer.Deserialize(DataPath) : new DataModel();

        public void Save()
        {
            DataSerializer.Serialize(DataPath, this);
        }
    }
}
