using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHP : MonoBehaviour
{
    public float maxHP = 5;
    public float currentHP;
    
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} »ç¸Á!");
        Destroy(gameObject);
    }
}
