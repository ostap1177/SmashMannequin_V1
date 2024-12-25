using UnityEngine;

namespace Entity
{
    public class Destriyer : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);
        }
    }
}