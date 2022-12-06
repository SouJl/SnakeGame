using Snake_Game.Interfaces;
using Snake_Game.Model;
using UnityEngine;

namespace Snake_Game.ViewModel 
{
    public class SnakeViewModel: IViewModel, IMove
    {
        private SnakeModel _snakeModel;

        public SnakeModel SnakeModel { get => _snakeModel;}

        public SnakeViewModel(SnakeModel snakeModel) 
        {
            _snakeModel = snakeModel;
        }

        public void Move(Vector3 direction)
        {
            SnakeModel.Move(direction);
        }

        public void AddTail(Transform transform) 
        {
            var newTailPart = new TailModel(SnakeModel.Head, transform);
            SnakeModel.AddTailPart(newTailPart);
        }
    }
}

