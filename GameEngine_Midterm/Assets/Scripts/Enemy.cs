using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float traceRange = 15f; // 추적 시작 거리
    public float attackRange = 6f; // 공격 시작 거리
    public float attackCooldown = 1.5f;

    //public GameObject projectilePrefab; // 투사체 프리팹
    //public Transform firePoint; // 발사 위치

    public Transform player;
    private float lastAttackTime;
    public float maxHP = 5;
    public float currentHP;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastAttackTime = -attackCooldown;
        currentHP = maxHP;
    }

    void Update()
    {
        if(player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(player.position);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} 사망!");
        Destroy(gameObject);
    }
}
