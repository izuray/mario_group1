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
            GameObject fire = Instantiate(Fire, FirePosition.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(15);
            Destroy(fire);
        }
    }
}
