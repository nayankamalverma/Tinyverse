using System.Collections;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] int rotationSpeed = 80;
    [SerializeField] float delayBetweenRotations = 1.0f;
    [SerializeField] bool rotateX = false;
    [SerializeField] bool rotateY = false;
    [SerializeField] bool rotateZ = false;

    void Start()
    {
        StartCoroutine(RotateWithDelay());
    }

    IEnumerator RotateWithDelay()
    {
        while (true)
        {
            float angle = 0;
            while (angle < 360)
            {
                float step = rotationSpeed * Time.deltaTime;
                angle += step;
                Vector3 rotation = new Vector3(
                    rotateX ? step : 0,
                    rotateY ? step : 0,
                    rotateZ ? step : 0
                );
                transform.Rotate(rotation);
                yield return null;
            }
            yield return new WaitForSeconds(delayBetweenRotations);
        }
    }
}
