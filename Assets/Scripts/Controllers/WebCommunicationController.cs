using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Models;
using CrossoverGame.Views;
using CrossoverGame.Components;

namespace CrossoverGame.Controllers
{
    public class WebCommunicationController
    {
        public delegate void ControllerGETSuccess(StacksJSON[] stacksJSON);
        public event ControllerGETSuccess OnGetSuccess;

        private readonly WebCommunicationModel _webCommunicationModel;
        private readonly WebCommunicationView _webCommunicationView;

        public WebCommunicationController(WebCommunicationModel webCommunicationModel, WebCommunicationView webCommunicationView)
        {
            _webCommunicationModel = webCommunicationModel;
            _webCommunicationView = webCommunicationView;
            _webCommunicationView.OnGetSuccess += WebCommunicationView_OnGetSuccess;
            _webCommunicationView.GetGameState(_webCommunicationModel.ApiURI);
        }

        private void WebCommunicationView_OnGetSuccess(StacksJSON[] stacksJSON) => OnGetSuccess(stacksJSON);
    }
}
