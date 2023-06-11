using UnityEngine;

public class Turret : MonoBehaviour
{
    public int numCannons = 8;
    public GameObject cannonPrefab;
    public float firingRange = 10f;
    public float fireInterval = 1f; 
    public Transform target;
    private bool canFire = false;
    private float nextFireTime;

    private void Start()
    {
        nextFireTime = Time.time;
    }

    private void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            canFire = distanceToTarget <= firingRange;

            if (canFire && Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + fireInterval;
            }
        }
    }

    private void Fire()
    {
        
        float angleStep = 360f / numCannons;
        float currentAngle = 0f;

        for (int i = 0; i < numCannons; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, currentAngle, 0f);
            Vector3 direction = rotation * transform.forward;

            GameObject cannon = Instantiate(cannonPrefab, transform.position, rotation);
            cannon.GetComponent<s_Bala360>().FireInLine();

            currentAngle += angleStep;
        }
    }
}





