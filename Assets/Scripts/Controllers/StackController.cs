using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrossoverGame.Models;
using CrossoverGame.Views;
using System.Linq;

namespace CrossoverGame.Controllers
{
    public class StackController
    {
        private Dictionary<BlockModel, BlockView> _blockDictionary = new();
        private List<BlockModel> _blockModelList = new();
        private List<BlockView> _blockViewList = new();

        public void AddBlockToList(BlockModel blockModel, BlockView blockView)
        {
            _blockModelList.Add(blockModel);
            _blockViewList.Add(blockView);
        }

        /// <summary>
        /// This method will put in place every instantiated block
        /// </summary>
        public void SetBlocksPosition(Vector3 initialPosition)
        {
            IEnumerable sortedModelList = _blockModelList.OrderBy(s => s.Domain).ThenBy(s => s.Cluster).ThenBy(s => s.Standardid); //This Linq function is positioning the blocks in the order required
            List<BlockView> sortedViewList = new();

            foreach (BlockModel model in sortedModelList)
            {
                foreach (BlockView view in _blockViewList)
                {
                    if (model.Id == view.Id)
                    {
                        sortedViewList.Add(view);
                        _blockDictionary.Add(model, view);
                    }
                }
            }

            int count = 1;
            int countY = 0;
            int countZ = 0;
            int rotationY = 0;
            int zOffset = 2;
            float rotateStart = initialPosition.x + 2f;
            foreach (KeyValuePair<BlockModel, BlockView> block in _blockDictionary)
            {
                if (rotationY == 0)
                {
                    block.Value.transform.localPosition = new Vector3(initialPosition.x, initialPosition.y + countY, zOffset * countZ);
                    block.Value.transform.localEulerAngles = new Vector3(0, rotationY);
                    
                    countZ++;
                    if (IsMultipleOf3(count) != 0)
                    {
                        countZ = 0;
                        countY++;
                        rotationY = 90;
                    }
                }
                else
                {
                    block.Value.transform.localPosition = new Vector3(rotateStart, initialPosition.y + countY, zOffset);
                    block.Value.transform.localEulerAngles = new Vector3(0, rotationY);
                    rotateStart = rotateStart - 2;
                    if (IsMultipleOf3(count) != 0)
                    {
                        rotateStart = initialPosition.x + 2f;
                        countY++;
                        rotationY = 0;
                    }
                }
                count++;
            }
        }

        private int IsMultipleOf3(int n)
        {
            int odd_count = 0, even_count = 0;

            if (n < 0)
                n = -n;
            if (n == 0)
                return 1;
            if (n == 1)
                return 0;

            while (n != 0)
            {

                if ((n & 1) != 0)
                    odd_count++;

                if ((n & 2) != 0)
                    even_count++;

                n >>= 2;
            }

            return IsMultipleOf3(System.Math.Abs(odd_count - even_count));
        }

    }
}
