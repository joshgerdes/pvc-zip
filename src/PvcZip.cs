using PvcCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.IO;

namespace PvcPlugins
{
    public class PvcZip : PvcPlugin
    {
        private readonly string _archiveName;

		public PvcZip(string archiveName = "Archive")
		{
			_archiveName = archiveName;
		}

        public override IEnumerable<PvcStream> Execute(IEnumerable<PvcStream> inputStreams)
        {
            var outputStream = new MemoryStream();
            var returnStream = new PvcStream(() => outputStream);
            ZipFile zip = new ZipFile();

            foreach (var inputStream in inputStreams)
            {
                ZipEntry e = zip.AddEntry(inputStream.StreamName, inputStream);
            };

            zip.Save(outputStream);
            
			return new[]
			{
				returnStream.As(String.Format("{0}.zip", _archiveName))
			};
        }
    }
}
