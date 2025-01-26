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
            body.mass = 1;
           body.gravityScale = 1;

        }
        else
        {

            body.mass = 100f;
            body.gravityScale = 100f;

        }
    }
}
