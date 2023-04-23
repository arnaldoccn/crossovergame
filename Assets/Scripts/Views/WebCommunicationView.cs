using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using CrossoverGame.Components;

namespace CrossoverGame.Views
{
    public class WebCommunicationView : MonoBehaviour
    {

        public delegate void WebCommunicationGETSuccess(StacksJSON[] stacksJSON);
        public event WebCommunicationGETSuccess OnGetSuccess;

        public void GetGameState(string uri) => StartCoroutine(Get(uri));

        private IEnumerator Get(string uri)
        {
            UnityWebRequest unityWebRequest = UnityWebRequest.Get(uri);
            using UnityWebRequest webRequest = unityWebRequest;
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                   Debug.Log(webRequest.error);
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log(webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log(webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    OnGetSuccess(StacksJSON.CreateFromJSON(webRequest.downloadHandler.text));
                    break;
            }
        }
    }
}
