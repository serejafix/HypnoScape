using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Движующиеся платформа
public class Platform3Move : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 500f;

    private Vector2 targetPosition;

    void Start()
    {
        targetPosition = pointB.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, pointA.position) < .1f) targetPosition = pointB.position;

        if (Vector2.Distance(transform.position, pointB.position) < .1f) targetPosition = pointA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
