using UnityEngine;

public class ShrinkingAndExpanding : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    private Transform playerTransform;
    public float playerSizeMultiplier = 2.0f;
    private bool isExpanded = false;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isExpanded)
            {
                Expand();
            }
            else
            {
                Shrink();
            }
        }
    }

    public void Expand()
    {
        Debug.Log("Expanding");
        playerTransform.localScale *= playerSizeMultiplier;
        isExpanded = true;
    }

    public void Shrink()
    {
        Debug.Log("Shrinking");
        playerTransform.localScale /= playerSizeMultiplier;
        isExpanded = false;
    }

    public bool isTopClear()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, transform.up, castDistance, groundLayer))
        {
            Debug.Log("Is clear");
            return true;
        }
        else
        {
            Debug.Log("Is not clear");
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
}
