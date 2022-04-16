using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timer
    {
        private float _elapsedTime;
        private bool _isStoped;

        public IEnumerator CountDown()
        {
            _isStoped = false;
            _elapsedTime = 0;
            while (!_isStoped)
            {
                _elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        public float Stop()
        {
            _isStoped = true;
            return _elapsedTime;
        }
    }
}
