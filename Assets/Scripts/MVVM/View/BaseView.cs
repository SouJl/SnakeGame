using Snake_Game.Interfaces;
using UnityEngine;

namespace Snake_Game.View
{
    public abstract  class BaseView: MonoBehaviour
    {
        public abstract void Init(IViewModel viewModel);

        public abstract void Interaction(Collider other);
        
        private void OnTriggerEnter(Collider collider)
        {
            Interaction(collider);
        }
    }
}
