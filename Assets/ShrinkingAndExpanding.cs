using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShrinkingAndExpanding : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    private Transform playerTransform;
    public float playerSizeMultiplier = 2.0f;
    public bool isExpanded = false;
    public bool isTopClear = true;


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
            Debug.Log(isTopClear);

            if (isTopClear)
            {
                if (!isExpanded)
                {
                    Expand();
                    return;
                }
            }

            if (isExpanded)
            {
                Shrink();
                return;
            }

        }
    }

    public void Expand()
    {
        //Debug.Log("Expanding");
        playerTransform.localScale *= playerSizeMultiplier;
        isExpanded = true;
    }

    public void Shrink()
    {
        //Debug.Log("Shrinking");
        playerTransform.localScale /= playerSizeMultiplier;
        isExpanded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isTopClear = false;
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isTopClear = true;
            return;
        }
    }




}

