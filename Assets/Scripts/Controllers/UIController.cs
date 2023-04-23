using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Models;
using CrossoverGame.Views;

namespace CrossoverGame.Controllers
{
    public class UIController
    {
        private UIModel _uiModel;
        private UIView _uiView;
        private BlockPropertiesView _blockPropertiesView;

        public UIController(UIModel uiModel, UIView uiView, BlockPropertiesView blockPropertiesView)
        {
            _uiModel = uiModel;
            _uiView = uiView;
            _blockPropertiesView = blockPropertiesView;
        }

        public void InactiveBlockPropertiesView() => _blockPropertiesView.Inactive();
    }
}
