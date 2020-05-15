using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MasjidProjectV2.Dtos
{
    public class CityDto
    {

        [JsonProperty(PropertyName = "nr")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "navn")]
        public string Name { get; set; }
    }
}