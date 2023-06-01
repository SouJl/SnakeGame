using UnityEngine;

namespace Snake_Game.View
{
    public class PointView:MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other);
        }
    }
}
