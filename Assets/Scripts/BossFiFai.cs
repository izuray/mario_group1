using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BossFiFai : MonoBehaviour
{
    public GameObject Fire;
    public GameObject FirePosition;
    public float speed;
    

    private float count = 0;

    [Header("Jump")]
    public float jump;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = Vector2.left * speed;
        StartCoroutine(FireShoot());
    }

    private IEnumerator FireShoot() {
        count += Time.deltaTime;
        if (count > 10) {
            count = 0;
            yield return new WaitForSeconds(1);
            GameObject fire1 = Instantiate(Fire, FirePosition.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
            yield return new WaitForSeconds(2);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            yield return new WaitForSeconds(0.2f);
            GameObject fire2 = Instantiate(Fire, FirePosition.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(6);
            Destroy(fire1);
            yield return new WaitForSeconds(4);
            Destroy(fire2);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Player player = other.gameObject.GetComponent<Player>();
            player.Hit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Player player = other.gameObject.GetComponent<Player>();
            player.Hit();
        }
    }
}
