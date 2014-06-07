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
        private readonly string _password;

		public PvcZip(string password = "", string name = "Archive")
		{
			_archiveName = name;
            _password = password;
		}

        public override IEnumerable<PvcStream> Execute(IEnumerable<PvcStream> inputStreams)
        {
            var outputStream = new MemoryStream();
            var returnStream = new PvcStream(() => outputStream);
            ZipFile zip = new ZipFile();

            if (!String.IsNullOrEmpty(_password))
            {
                zip.Password = _password;
            }

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
