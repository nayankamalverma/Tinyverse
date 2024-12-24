using System.Collections;
using UnityEngine;

public class Coins : MonoBehaviour
{
	[SerializeField] bool isScalable;
	[SerializeField] Vector3 minScale;
	[SerializeField] Vector3 maxScale;
	[SerializeField] float scalingDuration = 1f;
	[SerializeField] int rotationSpeed = 80;
	[SerializeField] float delayBetweenRotations = 1.0f;
	[SerializeField] bool rotateX = false;
	[SerializeField] bool rotateY = false;
	[SerializeField] bool rotateZ = false;
	private bool scalingUp = true;
	private float scalingTimer = 0f;
   
	private void Start()
	{
		//StartCoroutine(RotateWithDelay());
	}

	private void Update()
	{
		//if (isScalable) Scalable();
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
   




