using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAtak : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots; // Масив точок переміщення
    private int currentSpot = 0;

    Transform player;
    public float stoppingDistance;

    bool chill = true; // Початковий стан - патрулювання
    bool angry = false;
    bool goBack = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        else if (distanceToPlayer >= stoppingDistance && !chill)
        {
            goBack = true;
            angry = false;
        }

        if (chill)
        {
            Patrol();
        }
        else if (angry)
        {
            Attack();
        }
        else if (goBack)
        {
            GoBack();
        }
    }

    void Patrol()
    {
        // Перевірка, чи досягнута поточна точка патрулювання
        if (Vector2.Distance(transform.position, moveSpots[currentSpot].position) < 0.2f)
        {
            if (currentSpot < moveSpots.Length - 1)
            {
                currentSpot++;
            }
            else
            {
                currentSpot = 0;
            }
        }

        // Рух до наступної точки
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[currentSpot].position, speed * Time.deltaTime);
    }

    void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[0].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[0].position) < 0.1f)
        {
            goBack = false;
            chill = true;
        }
    }
}