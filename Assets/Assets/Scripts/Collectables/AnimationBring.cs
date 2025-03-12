using UnityEngine;

public class AnimationBring : MonoBehaviour
{
    [SerializeField] GameObject own;
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.Instance.Play(SoundType.genricPickup);
            Destroy(own);
            Destroy(obj1);
            obj2.SetActive(true);
        }
    }
}
