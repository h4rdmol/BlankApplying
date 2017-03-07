using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace BlankApplying.Models
{
    class Countries
    {
        [JsonProperty("cid")]
        public int cid { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }

        public Countries()
        {
            cid = 0;
            title = null;
        }
        public Countries(int cid, string title)
        {
            this.cid = cid;
            this.title = title;
        }
    }
}
