using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputController
    {
        public event Action CloseButtonPressed;
        public event Action<Ball.MoveDirection> MoveButtonPressed;

        Ball _ball;

        public InputController(Ball ball)
        {
            _ball = ball;
        }

        public void CheckInput()
        {
            if (Input.GetKey(KeyCode.W))
                MoveButtonPressed?.Invoke(Ball.MoveDirection.forward);
            if (Input.GetKey(KeyCode.A))
                MoveButtonPressed?.Invoke(Ball.MoveDirection.left);
            if (Input.GetKey(KeyCode.S))
                MoveButtonPressed?.Invoke(Ball.MoveDirection.backward);
            if (Input.GetKey(KeyCode.D))
                MoveButtonPressed?.Invoke(Ball.MoveDirection.right);          
            if (Input.GetKey(KeyCode.Escape))
                CloseButtonPressed?.Invoke();
        }
    }
}
