using Snake_Game.Interfaces;
using Snake_Game.Model;
using UnityEngine;

namespace Snake_Game.ViewModel
{
    public class SnakeViewModel : IViewModel, IMove
    {
        private SnakeModel _snakeModel;

        public SnakeModel SnakeModel { get => _snakeModel; }

        public Vector3 LastTailPos
        {
            get 
            {
                if (SnakeModel.Tail == null)
                    return Vector3.zero;
                else
                    return SnakeModel.Tail.GetLastPos();
            }
        }


        public SnakeViewModel(SnakeModel snakeModel)
        {
            _snakeModel = snakeModel;
        }

        public void Move(Vector3 direction)
        {
            SnakeModel.Move(direction);
        }

        public void AddTail(Transform transform, int tailGap)
        {
            var newTailPart = new TailModel(SnakeModel.Head, transform, tailGap);
            SnakeModel.AddTailPart(newTailPart);
        }

        public void Reset()
        {

        }
    }
}

