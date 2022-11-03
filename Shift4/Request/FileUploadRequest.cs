using Newtonsoft.Json;
using Shift4.Converters;
using Shift4.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shift4.Request
{
    public class FileUploadRequest
    {
        [JsonProperty("purpose")]
        [JsonConverter(typeof(SafeEnumConverter))]
        public FileUploadPurpose Purpose { get; set; }

        public byte[] File { get; set; }

        public string FileName { get; set; }
    }
}
