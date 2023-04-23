using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossoverGame.Tools
{
    public partial class JsonHelper
    {
        /// <summary>
        /// This method will allow us to get and array of objects using the Unity standard JSON class
        /// </summary>
        public static T[] GetJsonArray<T>(string json)
        {
            var newJson = "{ \"array\": " + json + "}";
            var wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.array;
        }
    }
}
