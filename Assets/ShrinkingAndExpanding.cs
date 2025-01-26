using System.Collections;
using UnityEngine;

public class ShrinkingAndExpanding : MonoBehaviour
{
    private Transform playerTransform;
    public float playerSizeMultiplier = 2.0f;
    public float expandDuration = 0.5f;   // How long (in seconds) to complete expand
    public float shrinkDuration = 0.5f;   // How long (in seconds) to complete shrink

    public bool isExpanded = false;
    public bool isTopClear = true;

    public Rigidbody2D playerrb;
    public PlayerMovement player;

    private Coroutine scaleRoutine;
    public Animator animator;
    public RuntimeAnimatorController con1;
    public RuntimeAnimatorController con2;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Only let the scale begin if we are not already in the middle of scaling
            if (scaleRoutine != null)
            {
                StopCoroutine(scaleRoutine);
            }

            if (isTopClear && !isExpanded)
            {
                FindFirstObjectByType<AudioManager>().Play("turnbig", 1f, 0.3f, false);

                // Expand over time
                scaleRoutine = StartCoroutine(DoScaleOverTime(
                    playerSizeMultiplier, expandDuration));
            }
            else if (isExpanded)
            {
                // Shrink over time
                FindFirstObjectByType<AudioManager>().Play("deflate", 1f, 0.3f, false);

                scaleRoutine = StartCoroutine(DoScaleOverTime(
                    1f / playerSizeMultiplier, shrinkDuration));
            }
        }
    }

    private IEnumerator DoScaleOverTime(float multiplier, float duration)
    {
        // Remember original scale
        Vector3 startScale = playerTransform.localScale;
        Vector3 endScale = startScale * multiplier;

        float timeElapsed = 0f;

        // While we're not done interpolating
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / duration;

            // Lerp from the old scale to the new one
            playerTransform.localScale = Vector3.Lerp(startScale, endScale, t);

            // Wait for one frame
            yield return null;
        }

        // Make absolutely sure we reach our final target scale
        playerTransform.localScale = endScale;

        // Toggle isExpanded based on the multiplier
        isExpanded = multiplier > 1f;

        // Now adjust speed, jump, etc.
        if (isExpanded)
        {
            // Expand "final" values
            animator.runtimeAnimatorController = con1;
            player.isGrowing = false;
            player.isJumping = false;
            player.isIdle = false;
            player.isWalking = false;


            player.jumpingPower = 13f;
            player.speed = 2f;
            playerrb.mass = 1;
            playerrb.gravityScale = 1.5f;
        }
        else
        {
            player.isGrowing = false;
            player.isJumping = false;
            player.isIdle = false;
            player.isWalking = false;
            // Shrink "final" values
            animator.runtimeAnimatorController = con2;

            player.jumpingPower = 8f;
            player.speed = 4f;
            playerrb.mass = 1;
            playerrb.gravityScale = 1.5f;
        }

        // Clear the routine reference
        scaleRoutine = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isTopClear = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isTopClear = true;
        }
    }
}

