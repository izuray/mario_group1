using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotation : MonoBehaviour
{

    public float speedRotate = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotate = Quaternion.Euler(0, 0, speedRotate * Time.deltaTime);
        transform.rotation *= rotate;
    }
}
