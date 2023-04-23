using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace CrossoverGame.Views
{
    public class BlockView : MonoBehaviour
    {
        private int _id;
        public delegate void BlockViewClick(BlockView blockView, BlockPropertiesView blockPropertiesView);
        public event BlockViewClick OnClick;

        [SerializeField]    
        private Material[] _materials;

        [SerializeField]
        private TextMeshPro _masteryLabel;

        [SerializeField]
        private List<PhysicMaterial> _physicMaterials;

        private BlockPropertiesView _blockPropertiesView;

        public int Id { get => _id; }

        private void Awake() => _blockPropertiesView = FindFirstObjectByType<BlockPropertiesView>();

        private void OnMouseUp()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            OnClick(this, _blockPropertiesView);
        }

        public void SetTextureLabelAndId(int mastery,
                                         int id,
                                         List<int> massList,
                                         List<string> labelList)
        {
            _id = id;
            _materials[mastery].mainTextureScale = GetComponent<MeshRenderer>().material.mainTextureScale;
            GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material.name.StartsWith(_materials[mastery].name) ? GetComponent<MeshRenderer>().material : _materials[mastery];
            switch (mastery)
            {
                case 0:
                    _masteryLabel.text = labelList[0];
                    GetComponent<Rigidbody>().mass = massList[0];
                    GetComponent<BoxCollider>().material = _physicMaterials[0];
                    break;
                case 1:
                    _masteryLabel.text = labelList[1];
                    GetComponent<Rigidbody>().mass = massList[1];
                    GetComponent<BoxCollider>().material = _physicMaterials[1];
                    break;
                case 2:
                    _masteryLabel.text = labelList[2];
                    GetComponent<Rigidbody>().mass = massList[2];
                    GetComponent<BoxCollider>().material = _physicMaterials[2];
                    break;
                default:
                    break;
            }
        }
    }
}
