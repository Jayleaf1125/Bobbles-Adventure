using UnityEngine;

public class BoxScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ShrinkingAndExpanding player;
    public Rigidbody2D body;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<ShrinkingAndExpanding>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isExpanded)
        {
            Debug.Log("hurr");
            body.mass = 1;
        }
        else
        {
            Debug.Log("burr");

            body.mass = 100f;

        }
    }
}
