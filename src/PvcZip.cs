using PvcCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using Ionic.Zlib;
using System.IO;

namespace PvcPlugins
{
    public class PvcZip : PvcPlugin
    {
        private readonly string _archiveName;
        private readonly string _password;
        private readonly CompressionLevel _level = CompressionLevel.Default;

		public PvcZip(string password = "", string name = "Archive", string level = "default")
		{
			_archiveName = name;
            _password = password;
            _level = _getCompressionLevel(level);       
		}

        public override IEnumerable<PvcStream> Execute(IEnumerable<PvcStream> inputStreams)
        {
            var outputStream = new MemoryStream();
            var returnStream = new PvcStream(() => outputStream);
            ZipFile zip = new ZipFile();
            zip.CompressionLevel = _level;

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

        private CompressionLevel _getCompressionLevel(string levelName) {
            CompressionLevel level;

            switch (levelName.ToLower())
            {
                case "best":
                    level = CompressionLevel.BestCompression;
                    break;
                case "speed":
                    level = CompressionLevel.BestSpeed;
                    break;
                case "none":
                    level = CompressionLevel.None;
                    break;
                case "default":
                    level = CompressionLevel.Default;
                    break;
                case "0":
                    level = CompressionLevel.Level0;
                    break;
                case "1":
                    level = CompressionLevel.Level1;
                    break;
                case "2":
                    level = CompressionLevel.Level2;
                    break;
                case "3":
                    level = CompressionLevel.Level3;
                    break;
                case "4":
                    level = CompressionLevel.Level4;
                    break;
                case "5":
                    level = CompressionLevel.Level5;
                    break;
                case "6":
                    level = CompressionLevel.Level6;
                    break;
                case "7":
                    level = CompressionLevel.Level7;
                    break;
                case "8":
                    level = CompressionLevel.Level8;
                    break;
                case "9":
                    level = CompressionLevel.Level9;
                    break;
                default:
                    level = CompressionLevel.Default;
                    break;
            }        

            return level;
        }
    }
}
