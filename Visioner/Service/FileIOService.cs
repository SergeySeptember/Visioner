using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visioner;
using Newtonsoft.Json;

namespace Visioner.Service
{
    class FileIOService
    {
        
        public readonly string _filePath;

        public FileIOService(string path)
        {
            _filePath = path;
        }
        public BindingList<string> LoadData()
        {
            var fileExists = File.Exists(_filePath);
            if (!fileExists)
            {
                File.CreateText(_filePath).Dispose();
                return new BindingList<string>();
            }
            using (var reader = File.OpenText(_filePath))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<string>>(fileText);
            }
        }

        public void SaveData(object listOfCases)
        {
            using (StreamWriter writer = File.CreateText(_filePath))
            {
                string output = JsonConvert.SerializeObject(listOfCases);
                writer.Write(output);
            }

        }
        
    }
}
