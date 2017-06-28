using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CommonFrameWork.Serialization
{
    /// <summary>
    /// 默认序列化实现
    /// </summary>
    public class DefaultObjectSerializer : IObjectSerializer
    {
        #region IObjectSerializer Members

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual string Serialize<TObject>(TObject obj)
        {
            DataContractJsonSerializer dataContractSerializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                dataContractSerializer.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public virtual TObject Deserialize<TObject>(string str)
        {
            DataContractJsonSerializer dataContractSerializer = new DataContractJsonSerializer(typeof(TObject));
            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str)))
            {
                return (TObject)dataContractSerializer.ReadObject(ms);
            }
        }

        #endregion
    }
}
