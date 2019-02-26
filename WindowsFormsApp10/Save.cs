using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp10
{
    class Save
    {
        public void SerializeObject(string fileName, object objToSerialize)
        {
            FileStream fstream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, objToSerialize);
            fstream.Close();
        }

        public object DeserializeObject(string fileName)
        {
            object objToSerialize = null;
            FileStream fstream_ = File.Open(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            objToSerialize = (object) binaryFormatter.Deserialize(fstream_);
            fstream_.Close();
            return objToSerialize;
        }

    }
}
