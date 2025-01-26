using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Variables for the game
    Health damage;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        damage = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollissionEnter2d(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            Debug.Log("Burger");
            damage.TakeDamage(1); // Deal damage to the player
        }
    }
}
