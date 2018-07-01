using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    public sealed class Json 
    {
        #region Fields

        static readonly JsonSerializerSettings _setting = null;

        #endregion
        #region Constructor

        static Json()
        {
            _setting = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        #endregion
        #region Method.Public

        #region Method.Public.Deserialize

        public static Object Deserialize(string jsonData, Type type)
        {
            return JsonConvert.DeserializeObject(jsonData, type, _setting);
        }

        #endregion
        #region Method.Public.Serialize

        public static String Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize, _setting);
        }

        #endregion

        #endregion
    }
}
