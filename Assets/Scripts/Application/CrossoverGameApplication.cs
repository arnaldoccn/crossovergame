using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Factories;
using CrossoverGame.Components;
using CrossoverGame.Controllers;
using CrossoverGame.Views;

namespace CrossoverGame.Application
{
    /* This project was built in a AFMVCC (Application, Factory, Model, View, Controller and Component) pattern,
    * this is the class responsible for the Application layer. It's the entry point of the game and contain all critical instances.
    */
    public class CrossoverGameApplication : MonoBehaviour
    {
        [SerializeField]
        private WebCommunicationFactory _webCommunicationFactory;
        [SerializeField]
        private BlockFactory _blockFactory;
        [SerializeField]
        private UIFactory _uiFactory;
        [SerializeField]
        private StackFactory _stackFactory;

        void Start()
        {
            //On the start we will get all the factories dispatched events
            _webCommunicationFactory.OnGetSuccess += WebCommunicationFactory_OnGetSuccess;
            _blockFactory.OnClick += BlockFactory_OnClick;
            _blockFactory.OnBlocksInstantiated += BlockFactory_OnBlocksInstantiated;
        }

        private void BlockFactory_OnBlocksInstantiated(List<BlockController> blockControllers)
        {
            _uiFactory.InactiveBlockPropertiesView();
            _stackFactory.SetStacks(blockControllers);
        }

        private void BlockFactory_OnClick(string gradeLevel, string domain, string cluster, string standardId, string standardDescription, BlockPropertiesView blockPropertiesView)
        {
            _uiFactory.ShowBlockProperties(gradeLevel, domain, cluster, standardId, standardDescription, blockPropertiesView);
        }

        private void WebCommunicationFactory_OnGetSuccess(StacksJSON[] stacksJSON)
        {
            _blockFactory.CreateBlocks(stacksJSON);
        }
    }
}
