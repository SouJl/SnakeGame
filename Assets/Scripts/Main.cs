using Snake_Game.Model;
using Snake_Game.View;
using Snake_Game.ViewModel;
using UnityEngine;

namespace Snake_Game
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SnakeView _snakeView;

        private void Start()
        {
            HeadModel snakeHead = new HeadModel(_snakeView.Transform, _snakeView.Speed);
            var snakeViewModel = new SnakeViewModel(new SnakeModel(snakeHead));

            _snakeView.Init(snakeViewModel);

            _snakeView.AddTail();
            _snakeView.AddTail();
            _snakeView.AddTail();
        }
    }
}
