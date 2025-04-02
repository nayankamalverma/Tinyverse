using UnityEngine;

namespace Assets.Scripts.Player
{
    public class projectileBall : MonoBehaviour
    {
        private void Update()
        {
            Destroy(gameObject, 2);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "enemy")
            {
                Debug.Log("hit enemy");
            }
        }
    }
}