using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Tools;

namespace CrossoverGame.Components
{
    [System.Serializable]
    public class StacksJSON
    {
        public int id;
        public string subject;
        public string grade;
        public int mastery;
        public string domainid;
        public string domain;
        public string cluster;
        public string standardid;
        public string standarddescription;

        public static StacksJSON[] CreateFromJSON(string jsonString) => JsonHelper.GetJsonArray<StacksJSON>(jsonString);
    }
}
