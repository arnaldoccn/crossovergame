using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Controllers;
using CrossoverGame.ScriptableObjects;

namespace CrossoverGame.Factories
{
    public class StackFactory : MonoBehaviour
    {
        private const string sixthGrade = "6th Grade";
        private const string seventhGrade = "7th Grade";
        private const string eightGrade = "8th Grade";
        [SerializeField]
        private ConstantsScriptableObject _constants;

        private StackController _stackA, _stackB, _stackC;

        private void Start()
        {
            _stackA = new();
            _stackB = new();
            _stackC = new();
        }

        public void SetStacks(List<BlockController> blockControllers)
        {
            foreach (BlockController blockController in blockControllers)
            {
                switch (blockController.BlockModel.Grade)
                {
                    case sixthGrade:
                        _stackA.AddBlockToList(blockController.BlockModel, blockController.BlockView);
                        break;
                    case seventhGrade:
                        _stackB.AddBlockToList(blockController.BlockModel, blockController.BlockView);
                        break;
                    case eightGrade:
                        _stackC.AddBlockToList(blockController.BlockModel, blockController.BlockView);
                        break;
                    default:
                        break;
                }
            }
            _stackA.SetBlocksPosition(_constants.stackAPosition);
            _stackB.SetBlocksPosition(_constants.stackBPosition);
            _stackC.SetBlocksPosition(_constants.stackCPosition);
        }
    }
}
