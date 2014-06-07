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
    public class PvcUnzip : PvcPlugin
    {
        private readonly string _password;

		public PvcUnzip(string password = "")
		{
            _password = password;
		}

        public override string[] SupportedTags
        {
            get
            {
                return new[] { ".zip", ".bzip", "zlib" };
            }
        }

        public override IEnumerable<PvcStream> Execute(IEnumerable<PvcStream> inputStreams)
        {
            var resultStreams = new List<PvcStream>();

            foreach (var inputStream in inputStreams)
            {              
                ZipFile zip = ZipFile.Read(inputStream);

                foreach (ZipEntry e in zip)
                {
                    var outputStream = new ZipMemoryStream();

                    if (!String.IsNullOrEmpty(_password))
                    {
                        e.Password = _password;
                    }
  
                    e.Extract(outputStream);
                    var resultStream = new PvcStream(() => outputStream);
                    resultStream.Tags.Add("unzipped");
                    resultStreams.Add(resultStream.As(e.FileName));
                }          
            };

            return resultStreams;
        }
    }
}
