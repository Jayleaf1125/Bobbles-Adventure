using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("References")]
    public GameObject player;

    [Header("Camera Constraints")]
    [Tooltip("Minimum Y position that the camera cannot go below.")]
    public float minY = 0f;

    private void Start()
    {
        // Find the player GameObject if not assigned in the Inspector
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Get the player's current y position
            float targetY = player.transform.position.y;
 
            // Clamp the y position so it does not go below minY
            if (targetY < minY)
            {
                targetY = minY;
            }

            // Update the camera position, preserving the desired x and z
            transform.position = new Vector3(
                player.transform.position.x,
                targetY,
                -10f
            );
        }
    }
}
