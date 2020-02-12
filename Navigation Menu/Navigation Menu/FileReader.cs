using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation_Menu
{
    class FileReader
    {
        public string FilePath { get; private set; }

        public FileReader(string path) {
            FilePath = path;
        }
        
        public string[] getData() {
            return File.ReadAllLines(FilePath).Skip(1).ToArray<string>();
        }
    }

}
