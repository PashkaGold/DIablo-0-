using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float attackRange = 1.5f;
    public Rigidbody2D rb;
    private Vector2 direction;
    public Animator animator;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        // �������� ����� ��� ��� ����
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        // ������ ���������
        Vector2 movement = new Vector2(direction.x, direction.y).normalized;
        rb.velocity = movement * moveSpeed;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        // ���������, �� ������� �������� ������ ����� (���������, �����)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��������� ����� ��� ��������� �����
            Attack();
        }

    }


    void Attack()
    {
        // ���������, �� � ��'���� � ����������� �������
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            // ��� ����� ���������� ���� 䳿 �����, ���������, ���������� ������'� ������.
            // ���������, enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    // ������� ������� ����� ��� ����������
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void FixedUpdate()
    {

    }
}
