using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonFrameWork.Serialization;
using Newtonsoft.Json;

namespace CommonFrameWork.Extensions.NewTonSoft
{
    public class NewTonSoftSerializer : IObjectSerializer
    {
        #region Implementation of IObjectSerializer

        public string Serialize<TObject>(TObject obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public TObject Deserialize<TObject>(string str)
        {
            return JsonConvert.DeserializeObject<TObject>(str);
        }

        #endregion
    }
}
