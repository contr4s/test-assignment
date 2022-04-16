using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class UIController
    {
        [SerializeField] RectTransform _startScreen;
        [SerializeField] ResultScreen _resultsScreen;

        public void SetStartScreenActive(bool active)
        {
            _startScreen.gameObject.SetActive(active);
        }

        public void ShowResult(Result? result)
        {
            _resultsScreen.Setup(result);
        }

        public void CloseResultsScreen()
        {
            _resultsScreen.gameObject.SetActive(false);
        }
    }
}
