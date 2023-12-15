using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public Animator animator;
    private float waitTime;
    public float startWaitTime;
    public Rigidbody2D rb;
    public float moveSpeed = 1.0f;

    public Transform[] moveSpots;
    private int randomSpot;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }

    private void Update()
    {
        Vector2 movement = (moveSpots[randomSpot].position - transform.position).normalized;
        rb.velocity = movement * moveSpeed;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
