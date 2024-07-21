using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    [SerializeField] GameObject GameobjectAssets;
    [SerializeField] bool IsScalable;
    [SerializeField] Vector3 minscale;
    [SerializeField] Vector3 maxscale;
    [SerializeField] float scalingDuration = 1f;
    CoinCallector coinCallector;
    private bool scalingUp = true;
    private float scalingTimer = 0f;

    
    private void Update()
    {
        if (IsScalable)
        {
            Scalable();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
           // SoundManager.Instance.play(soundplaces.genricPickup);
            Destroy(GameobjectAssets);
           // Destroy(gameObject);
            coinCallector.incrementvalue(10);
        }
    }

    void Scalable()
    {
        scalingTimer = scalingTimer + Time.deltaTime;

        if (scalingUp)
        {
            transform.localScale = Vector3.Lerp(minscale, maxscale, scalingTimer / scalingDuration);
        }
        else
        {
            transform.localScale = Vector3.Lerp(maxscale, minscale, scalingTimer / scalingDuration);
        }

        if (scalingTimer >= scalingDuration)
        {
            scalingTimer = 0f;
            scalingUp = !scalingUp;
        }
    }



}

