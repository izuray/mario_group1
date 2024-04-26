using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Transform walling;
    public Transform wall;
    public Transform grounding;
    public Transform nextToPrincess;
    public GameObject[] bridge;
    public GameObject img;
    public float speed = 6f;
    public int nextWorld = 1;
    public int nextStage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LevelCompleteSequence(other.transform));
            StartCoroutine(DelBridge());
        }
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(1.6f);
        yield return MoveTo(player, walling.position);
        yield return MoveTo(player, wall.position);
        yield return MoveTo(player, grounding.position);
        yield return MoveTo(player, nextToPrincess.position);
        yield return new WaitForSeconds(.5f);
        img.SetActive(true);
    }

    private IEnumerator MoveTo(Transform subject, Vector3 position)
    {
        while (Vector3.Distance(subject.position, position) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, position, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = position;
    }

    private IEnumerator DelBridge()
    {
        for(int i = 0; i < bridge.Length; i++)
        {
            yield return new WaitForSeconds(.1f);
            bridge[i].gameObject.SetActive(false);
        }
        yield return null;
    }

}
