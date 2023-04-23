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
    public class BlockFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _blockPrefab;

        private readonly List<BlockController> _blockControllers = new();
        private BlockController _blockController;

        public delegate void BlockViewClick(string gradeLevel, string domain, string cluster, string standardId, string standardDescription, BlockPropertiesView blockPropertiesView);
        public event BlockViewClick OnClick;

        public delegate void BlocksInstantiated(List<BlockController> blockControllers);
        public event BlocksInstantiated OnBlocksInstantiated;

        private bool removedGlassFlag = false;

        [SerializeField]
        private ConstantsScriptableObject _constants;

        public void CreateBlocks(StacksJSON[] blocks)
        {
            int count = 0;
            foreach (var block in blocks)
            {
                if (block.grade != _constants.gradeToRemove)
                {
                    GameObject instantiatedBlock = Instantiate(_blockPrefab, new Vector3(0, count + 1.5f, 0), Quaternion.identity);
                    _blockControllers.Add(_blockController = new BlockController(
                        new BlockModel(block.id, block.subject, block.grade, block.mastery, block.domainid, block.domain, block.cluster, block.standardid, block.standarddescription, _constants),
                        instantiatedBlock.GetComponent<BlockView>()));
                    count++;
                    _blockController.OnClick += BlockController_OnClick;
                }
            }
            OnBlocksInstantiated(_blockControllers);
        }

        private void BlockController_OnClick(BlockModel blockModel,
                                             BlockPropertiesView blockPropertiesView) => OnClick(blockModel.Grade, blockModel.Domain, blockModel.Cluster, blockModel.Standardid, blockModel.Standarddescription, blockPropertiesView);

        public void RemoveGlass()
        {
            if (!removedGlassFlag)
            {
                foreach (var block in _blockControllers)
                {
                    if (block.BlockModel.Mastery == 0)
                    {
                        Destroy(block.BlockView.gameObject);
                    }
                }
                removedGlassFlag = true;
            }

        }
    }
}
