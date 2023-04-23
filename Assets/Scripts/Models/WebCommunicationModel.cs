using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.ScriptableObjects;

namespace CrossoverGame.Models
{
    public class WebCommunicationModel
    {
        private readonly ConstantsScriptableObject _constants;

        public WebCommunicationModel(ConstantsScriptableObject constants) => this._constants = constants;

        public string ApiURI { get => _constants.apiURI; }
    }
}
