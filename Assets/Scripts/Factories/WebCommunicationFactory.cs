using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Controllers;
using CrossoverGame.Models;
using CrossoverGame.Views;
using CrossoverGame.Components;
using CrossoverGame.ScriptableObjects;

namespace CrossoverGame.Factories
{
    public class WebCommunicationFactory : MonoBehaviour
    {
        public delegate void StackGETSuccess(StacksJSON[] stacksJSON);
        public event StackGETSuccess OnGetSuccess;

        [SerializeField]
        private ConstantsScriptableObject constants;

        [SerializeField]
        private GameObject webCommunicationViewPrefab;
        private WebCommunicationController webCommunicationController;

        void Start()
        {
            GameObject instantiatedWCV =  Instantiate(webCommunicationViewPrefab);
            webCommunicationController = new WebCommunicationController(new WebCommunicationModel(constants), instantiatedWCV.GetComponent<WebCommunicationView>());
            webCommunicationController.OnGetSuccess += WebCommunicationController_OnGetSuccess;
        }

        private void WebCommunicationController_OnGetSuccess(StacksJSON[] stacksJSON) => OnGetSuccess(stacksJSON);
    }
}
