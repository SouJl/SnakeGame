using UnityEngine;

namespace Snake_Game.Components
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollowComponent : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _zOffset = 0.5f;
        private void OnValidate()
        {
            _camera ??= GetComponent<Camera>();
        }

        
        void Update()
        {
            if (!_player) 
                return;

            var pos = new Vector3(
                transform.position.x, 
                transform.position.y, 
                _player.transform.position.z - _zOffset);

            transform.position = pos;
        }
    }
}


