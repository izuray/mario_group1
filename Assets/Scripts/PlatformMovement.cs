using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform currentPos;
    public Transform posA;
    public Transform posB;

    public float speed;

    float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = ChangePosition();
        currentPos.position = Vector3.MoveTowards(currentPos.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)currentPos.position).magnitude;
        if (distance <= 0.1f) {
            direction *= -1;
        }
    }

    private Vector2 ChangePosition() {
        if (direction == 1) {
            return posA.position;
        } else {
            return posB.position;
        }
    }
}
