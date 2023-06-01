using System.Threading.Tasks;
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

        [SerializeField] int _tailGap = 100;

        public Transform Transform { get => _transform; set => _transform = value; }

        public float Speed { get => _speed; }

        public int TailGap { get => _tailGap; set => _tailGap = value; }

        private GameActions _inputActions;

        private InputAction move;

        private SnakeViewModel _snakeViewModel;

        public override void Init(IViewModel viewModel)
        {
            if(viewModel is SnakeViewModel snakeViewModel) 
            {
                _snakeViewModel = snakeViewModel;
                
                AddTail();
                AddTail();
                AddTail();

                _inputActions = new GameActions();
                move = _inputActions.Player.Movement;
                move.Enable();
            }
            else 
            {
                Debug.Log($"Некорректная инициализация VieModel для {nameof(SnakeView)}");
            }
        }

        private void FixedUpdate()
        {
            _snakeViewModel.Move(move.ReadValue<Vector2>());
        }

        public override void Interaction(Collider collision)
        {
            if (collision.tag == "Fruit")
            {
                AddTail();
                Destroy(collision.gameObject);
            }
            if(collision.tag == "Border") 
            {
                ResetState();
            }
            if (collision.tag == "SnakeTail") 
            {
                if(collision.GetComponentInParent<TailView>().IsReady)
                    ResetState();
            }
        } 

        public void AddTail() 
        {
            var startpos = 
                _snakeViewModel.LastTailPos == Vector3.zero 
                ? _transform.position 
                : _snakeViewModel.LastTailPos;

            var tailView = Instantiate(_tailObject, startpos, Quaternion.identity).GetComponent<TailView>();
            _snakeViewModel.AddTail(tailView.TailTransform, TailGap);
        }

        private void ResetState() 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        private void OnDisable()
        {
            move.Disable();
        }
    }
}
