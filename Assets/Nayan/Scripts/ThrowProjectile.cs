using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] private float shootForce;
    private Animator animator;

    [SerializeField] private float timeBteweenShooting=3f, timeBetweenShots;

    int bulletsShoot;
    public bool shooting, readyToShoot;
    Rigidbody ball;

    [SerializeField] Transform throwPoint;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int lineSegmentCount = 10;

    private void Awake()
    {
        readyToShoot = true;
        animator = PlayerManager.instance.player.GetComponent<Animator>();
    }

    private void Update()
    {
        timeBetweenShots -= Time.deltaTime;
        if(timeBetweenShots<=0)
        {
            readyToShoot=true;
            timeBetweenShots = timeBteweenShooting;
        }
        fireInput();
        UpdateTrajectory();
    }

    void fireInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        GameObject projectile;
        if (readyToShoot && shooting) {

            animator.SetTrigger("attack");
            projectile = Instantiate(ballPrefab, throwPoint.position, throwPoint.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            Vector3 throwDirection = throwPoint.forward;

            rb.AddForce(throwDirection * shootForce, ForceMode.Impulse);
            readyToShoot = false;
        }
    }

    void UpdateTrajectory()
    {
        // Calculate the initial position and velocity
        Vector3 initialPosition = throwPoint.position;
        Vector3 initialVelocity = throwPoint.forward * shootForce / ballPrefab.GetComponent<Rigidbody>().mass;

        // Calculate the positions of the line segments
        Vector3[] trajectoryPoints = new Vector3[lineSegmentCount];
        for (int i = 0; i < lineSegmentCount; i++)
        {
            float time = i / (float)lineSegmentCount * 3; // Spread the points over 3 seconds
            trajectoryPoints[i] = CalculateTrajectoryPoint(initialPosition, initialVelocity, time);
        }

        // Set the positions in the LineRenderer
        lineRenderer.positionCount = lineSegmentCount;
        lineRenderer.SetPositions(trajectoryPoints);
    }

    Vector3 CalculateTrajectoryPoint(Vector3 startPosition, Vector3 startVelocity, float time)
    {
        // Calculate the position of the projectile at the given time using the equation of motion
        Vector3 gravity = Physics.gravity;
        Vector3 position = startPosition + startVelocity * time + 0.5f * gravity * time * time;
        return position;
    }


}
