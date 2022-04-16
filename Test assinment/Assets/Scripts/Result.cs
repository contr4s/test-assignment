using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public struct Result
    {
        public ResultType Type { get; }
        public float TimeSpent { get; }

        public Result(ResultType resultType, float timeSpent = 0)
        {
            Type = resultType;
            TimeSpent = timeSpent;
        }

        public enum ResultType
        {
            Victory,
            Lose
        }
    }
}
