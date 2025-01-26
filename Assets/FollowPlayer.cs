using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("References")]
    public GameObject player;

    [Header("Camera Constraints")]
    [Tooltip("Minimum Y position that the camera cannot go below.")]
    public float minY = 0f;

    [Tooltip("Minimum X position that the camera cannot go below.")]
    public float minX = -10f;

    [Tooltip("Maximum X position that the camera cannot go above.")]
    public float maxX = 10f;

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
            // Get the player's current X and Y positions
            float targetX = player.transform.position.x;
            float targetY = player.transform.position.y;

            // Clamp the Y position so it does not go below minY
            if (targetY < minY)
            {
                targetY = minY;
            }

            // Clamp the X position so it stays within [minX, maxX]
            targetX = Mathf.Clamp(targetX, minX, maxX);

            // Update the camera position, preserving the desired Z
            transform.position = new Vector3(
                targetX,
                targetY,
                -10f
            );
        }
    }
}
