using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector2 framingOffSet;
    [SerializeField] float distance=5;
    [SerializeField] Vector2 verticalAngleLimit = new Vector2(-30, 30);
    [SerializeField] float rotationSpeed = 2f; 
    
    float rotationX=0 ;
    float rotationY=0 ;


    private void Update()
    { 
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, verticalAngleLimit.x, verticalAngleLimit.y);

        rotationY += Input.GetAxis("Mouse X")*rotationSpeed;

       var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 focusPoint = target.position + new Vector3(framingOffSet.x,framingOffSet.y);

        transform.position = focusPoint - targetRotation  * new Vector3(0,0,distance);
        transform.rotation = targetRotation ;
    }
}
