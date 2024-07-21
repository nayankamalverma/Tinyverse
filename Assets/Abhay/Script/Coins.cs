using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Coins : MonoBehaviour
{
    [SerializeField] GameObject gameobjectAssets;
    [SerializeField] bool isScalable;
    [SerializeField] Vector3 minScale;
    [SerializeField] Vector3 maxScale;
    [SerializeField] float scalingDuration = 1f;
     [SerializeField]CoinCallector coinCallector;
    private bool scalingUp = true;
    private float scalingTimer = 0f;
   

    private void Start()
    {
        //coinCallector = FindObjectOfType<CoinCallector>();
    }

    private void Update()
    {
        if (isScalable)
        {
            Scalable();
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            SoundManager.Instance.play(soundplaces.genricPickup);
            Destroy(gameobjectAssets);
            coinCallector.incrementvalue(10);
        }
    }

    void Scalable()
    {
        scalingTimer += Time.deltaTime;

        if (scalingUp)
        {
            transform.localScale = Vector3.Lerp(minScale, maxScale, scalingTimer / scalingDuration);
        }
        else
        {
            transform.localScale = Vector3.Lerp(maxScale, minScale, scalingTimer / scalingDuration);
        }

        if (scalingTimer >= scalingDuration)
        {
            scalingTimer = 0f;
            scalingUp = !scalingUp;
        }
    }
   
}
   




