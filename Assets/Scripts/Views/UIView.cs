using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CrossoverGame.Components;
using CrossoverGame.Interfaces;

namespace CrossoverGame.Views
{
    public class UIView : MonoBehaviour
    {
        private const string sixthGrade = "6th Grade";
        private const string seventhGRade = "7th Grade";
        private const string eightGrade = "8th Grade";
        [SerializeField]
        private GameObject _firstFocus, _secondFocus, _thirdFocus;

        [SerializeField]
        private OrbitHandler orbitHandler;

        public void ChangeViewFocus(string newFocus)
        {
            switch (newFocus)
            {
                case sixthGrade:
                    orbitHandler.SetFocus(_firstFocus.transform);
                    break;
                case seventhGRade:
                    orbitHandler.SetFocus(_secondFocus.transform);
                    break;
                case eightGrade:
                    orbitHandler.SetFocus(_thirdFocus.transform);
                    break;
                default:
                    break;
            }
        }

        public void ShowBlockProperties(string gradeLevel,
                                        string domain,
                                        string cluster,
                                        string standardId,
                                        string standardDescription,
                                        BlockPropertiesView blockPropertiesView)
        {
            blockPropertiesView.Populate(gradeLevel, domain, cluster, standardId, standardDescription);
            blockPropertiesView.Interact(false);
        }

        public void HideBlockProperties(BlockPropertiesView blockPropertiesView) => blockPropertiesView.Interact(true);
    }
}
