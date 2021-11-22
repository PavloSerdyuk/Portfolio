using Koval_Bank_And_Branches.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Koval_Bank_And_Branches.Serialization
{
    class DataSerializer
    {
        public static void Serialize(string filePath, DataModel data)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(stream, data);
            }
        }

        public static DataModel Deserialize(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentException(nameof(filePath));
            }

            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                return formatter.Deserialize(stream) as DataModel;
            }
        }
    }
}

