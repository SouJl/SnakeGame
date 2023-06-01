using System.Threading.Tasks;
using Snake_Game.Interfaces;
using UnityEngine;

namespace Snake_Game.View
{
    public class TailView : BaseView
    {
        [SerializeField] private Transform _tailTransform;

        public Transform TailTransform => _tailTransform;

        public bool IsReady { get; private set; }

        private void Awake()
        {
            _tailTransform ??= gameObject.transform;
            IsReady = false;
            OnStartDelay();
        }

        public override void Init(IViewModel viewModel) { }

        public override void Interaction(Collider other) { }

        private async void OnStartDelay()
        {
            await Task.Delay(100);
            IsReady = true;
        }
    }
}
