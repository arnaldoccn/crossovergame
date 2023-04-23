using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Interfaces;
using TMPro;

namespace CrossoverGame.Views
{
    public class BlockPropertiesView : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TMP_Text _gradeLevelTMP, _clusterTMP, _standardIdTMP;

        public void Inactive() => gameObject.SetActive(false);

        public void Populate(string gradeLevel, string domain, string cluster, string standardId, string standardDescription)
        {
            _gradeLevelTMP.text = gradeLevel + " " + domain;
            _clusterTMP.text = cluster;
            _standardIdTMP.text = standardId + " " + standardDescription;
        }

        public void Interact(bool switchType)
        {
            if (!this.gameObject.activeSelf)
            {
                this.gameObject.SetActive(true);
            }
            else if(switchType)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
