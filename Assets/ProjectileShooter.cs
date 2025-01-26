using UnityEngine;

public class TimedProjectileShooter : MonoBehaviour
{
    [Header("Prefab & Settings")]
    [Tooltip("The projectile prefab to be instantiated.")]
    public GameObject projectilePrefab;

    [Tooltip("If true, projectiles will shoot left; otherwise, they shoot right.")]
    public bool shootLeft = false;

    [Tooltip("Speed at which the projectile travels.")]
    public float projectileSpeed = 5f;

    [Tooltip("Time interval (in seconds) between shots.")]
    public float shootInterval = 4f;

    // Internal timer to track when to fire next
    private float timeSinceLastShot;

    private void Start()
    {
        // Optionally, start by immediately shooting or wait the full interval
        // Setting timeSinceLastShot = shootInterval will cause an immediate shot in the first Update.
        timeSinceLastShot = shootInterval;
    }

    private void Update()
    {
        // Update the internal timer
        timeSinceLastShot += Time.deltaTime;

        // Check if enough time has passed to shoot again
        if (timeSinceLastShot >= shootInterval)
        {
            FireProjectile();
            timeSinceLastShot = 0f;  // Reset timer
        }
    }

    /// <summary>
    /// Instantiates and propels a projectile in the designated direction.
    /// </summary>
    private void FireProjectile()
    {
        // Instantiate the projectile at this object's position and rotation
        if(shootLeft)
        {
          GameObject newProjectile = Instantiate(projectilePrefab, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), transform.rotation);
              Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Decide the direction: left or right
            Vector2 direction = shootLeft ? Vector2.left : Vector2.right;

            // Set the projectile's velocity
            rb.linearVelocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogWarning("Projectile prefab has no Rigidbody2D! Please add one.");
        }
        }else
        {
          GameObject newProjectile = Instantiate(projectilePrefab, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), transform.rotation);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Decide the direction: left or right
            Vector2 direction = shootLeft ? Vector2.left : Vector2.right;

            // Set the projectile's velocity
            rb.linearVelocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogWarning("Projectile prefab has no Rigidbody2D! Please add one.");
        }

        }
        FindFirstObjectByType<AudioManager>().Play("blast", 1f, 0.3f, false);


    }
}
