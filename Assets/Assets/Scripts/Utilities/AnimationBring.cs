using Assets.Scripts.Main;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class AnimationBring : MonoBehaviour
    {
        [SerializeField] GameObject obj1;
        [SerializeField] GameObject obj2;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                SoundService.Instance.Play(SoundType.genricPickup);
                Destroy(gameObject);
                Destroy(obj1);
                obj2.SetActive(true);
            }
        }
    }
}