using UnityEngine;

namespace Snake_Game.View
{
    public class PoinView:MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other);
        }
    }
}
