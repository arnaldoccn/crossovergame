using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.ScriptableObjects;

namespace CrossoverGame.Models
{
    public class BlockModel
    {
        private readonly int _id;
        private readonly string _subject;
        private readonly string _grade;
        private readonly int _mastery;
        private readonly string _domainid;
        private readonly string _domain;
        private readonly string _cluster;
        private readonly string _standardid;
        private readonly string _standarddescription;
        private readonly ConstantsScriptableObject _constants;

        public int Id { get => _id; }
        public string Subject { get => _subject; }
        public string Grade { get => _grade; }
        public int Mastery { get => _mastery; }
        public string Domainid { get => _domainid; }
        public string Domain { get => _domain; }
        public string Cluster { get => _cluster; }
        public string Standardid { get => _standardid; }
        public string Standarddescription { get => _standarddescription; }

        public ConstantsScriptableObject Constants => _constants;

        public BlockModel(int id, string subject, string grade, int mastery, string domainid, string domain, string cluster, string standardid, string standarddescription, ConstantsScriptableObject constants)
        {
            _id = id;
            _subject = subject;
            _grade = grade;
            _mastery = mastery;
            _domainid = domainid;
            _domain = domain;
            _cluster = cluster;
            _standardid = standardid;
            _standarddescription = standarddescription;
            _constants = constants;
        }
    }
}