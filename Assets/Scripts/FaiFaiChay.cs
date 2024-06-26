using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaiFaiChay : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            Player player = other.gameObject.GetComponent<Player>();
            player.Hit();
        }
    }
}
