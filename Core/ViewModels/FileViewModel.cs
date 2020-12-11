using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multimidia.Api.Core.ViewModels
{
    public class FileViewModel
    {
        public string FileName { get; internal set; }
        public string ContentType { get; internal set; }
        public string Base64 { get; internal set; }
        public byte[] Bytes { get; internal set; }
    }
}
