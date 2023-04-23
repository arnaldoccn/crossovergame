using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Models;
using CrossoverGame.Views;

namespace CrossoverGame.Controllers
{
    public class BlockController
    {
        public delegate void BlockClick(BlockModel blockModel, BlockPropertiesView blockPropertiesView);
        public event BlockClick OnClick;

        private readonly BlockModel _blockModel;
        private readonly BlockView _blockView;

        public BlockModel BlockModel => _blockModel;

        public BlockView BlockView => _blockView;

        public BlockController(BlockModel blockModel, BlockView blockView)
        {
            _blockModel = blockModel;
            _blockView = blockView;
            List<int> massList = new();
            massList.Add(blockModel.Constants.glassMass);
            massList.Add(blockModel.Constants.woodMass);
            massList.Add(blockModel.Constants.stoneMass);
            List<string> masteryList = new();
            masteryList.Add(blockModel.Constants.mastery0);
            masteryList.Add(blockModel.Constants.mastery1);
            masteryList.Add(blockModel.Constants.mastery2);
            _blockView.SetTextureLabelAndId(_blockModel.Mastery, blockModel.Id, massList, masteryList);
            blockView.OnClick += BlockView_OnClick;
        }

        private void BlockView_OnClick(BlockView blockView, BlockPropertiesView blockPropertiesView) => OnClick(_blockModel, blockPropertiesView);
    }
}
