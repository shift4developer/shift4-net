using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Shift4.Request
{
    public class Expand {
        public List<string> Paths {get; set; }

        public Expand() {
            Paths = new List<string>();
        }

        public Expand add(string path){
            Paths.Add(path);
            return this;
        }
    }
}