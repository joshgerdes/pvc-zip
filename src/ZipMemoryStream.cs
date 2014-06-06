using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvcPlugins
{
    class ZipMemoryStream : MemoryStream
    {
        public override void Close()
        {

        }
    }
}
