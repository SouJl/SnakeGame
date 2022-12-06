using Snake_Game.Interfaces;
using Snake_Game.ViewModel;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Snake_Game.View 
{
    public sealed class SnakeView : BaseView
    {
        [SerializeField] private Transform _transform;

        [SerializeField] float _speed = 5f;

        [SerializeField] GameObject _tailObject;

        public Transform Transform { get => _transform; set => _transform = value; }

        public float Speed { get => _speed; }

        private GameActions _inputActions;

        private InputAction move;

        private SnakeViewModel _snakeViewModel;

        public override void Init(IViewModel viewModel)
        {
            if(viewModel is SnakeViewModel snakeViewModel) 
            {
                _snakeViewModel = snakeViewModel;
                
                _inputActions = new GameActions();
                move = _inputActions.Player.Movement;
                move.Enable();
            }
            else 
            {
                Debug.Log($"Некорректная инициализация VieModel для {nameof(SnakeView)}");
            }
           
        }

        private void Update()
        {
            _snakeViewModel.Move(move.ReadValue<Vector2>());
        }

        public override void Interaction(Collider other)
        {
            if (other.tag == "Fruit")
            {
                AddTail();
                Destroy(other.gameObject);
            }
        }

        public void AddTail() 
        {
            var tailTrans = Instantiate(_tailObject, _transform.position, Quaternion.identity).GetComponent<Transform>();
            _snakeViewModel.AddTail(tailTrans);
        }


        private void OnDisable()
        {
            move.Disable();
        }
    }
}
