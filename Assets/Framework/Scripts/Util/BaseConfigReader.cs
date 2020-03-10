 
using Newtonsoft.Json;
using System.Collections.Generic;

using UnityEngine;

namespace Config
{
    public class BaseConfigReader
    {
        
        protected Dictionary<int, T> LoadConfig<T>()
        {
            string dataName = typeof(T).Name;

            byte[] data = FileIO.LoadBytes("Global/Common/Data/json/" + dataName);
            string str = data.EncodingToString();

            Dictionary<int, T> lineses = default(Dictionary<int, T>);
            //lineses = JSON.ToObject<Dictionary<int, T>>(str);

           
            try
            {
                lineses = JsonConvert.DeserializeObject<Dictionary<int, T>>(str);
            }
            catch (System.Exception e)
            {
                Debug.LogError("name:" + typeof(T).Name);
                Debug.LogError("BaseConfigReader,str:" + str);
                Debug.LogError("BaseConfigReader,Exception:" + e);
            }
            return lineses;
        }
 
    }
}