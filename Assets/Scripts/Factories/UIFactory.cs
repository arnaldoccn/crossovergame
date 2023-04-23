using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Controllers;
using CrossoverGame.Models;
using CrossoverGame.Views;

namespace CrossoverGame.Factories
{
    public class UIFactory : MonoBehaviour
    {
        private UIController _uicontroller;

        [SerializeField]
        private BlockPropertiesView _blockPropertyView;

        private void Start() => _uicontroller = new UIController(new UIModel(), GetComponent<UIView>(), _blockPropertyView);

        public void ShowBlockProperties(string gradeLevel,
                                        string domain,
                                        string cluster,
                                        string standardId,
                                        string standardDescription,
                                        BlockPropertiesView blockPropertiesView) => GetComponent<UIView>().ShowBlockProperties(gradeLevel, domain, cluster, standardId, standardDescription, blockPropertiesView);

        public void InactiveBlockPropertiesView() => _uicontroller.InactiveBlockPropertiesView();
    }
}
