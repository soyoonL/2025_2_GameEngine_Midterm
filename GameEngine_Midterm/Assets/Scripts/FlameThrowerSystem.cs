using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerSystem : MonoBehaviour
{
    public ParticleSystem ps;
    public float damagePerHit = 10f;

    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    void Start()
    {
        if(ps == null)
        ps = GetComponent<ParticleSystem>();
    }

    
    void OnParticleCollision(GameObject other)
    {
       float numCollisionEvents = ps.GetCollisionEvents(other,collisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            Vector3 pos = collisionEvents[i].intersection;

            Enemy enemy = other.GetComponent<Enemy>();
            CoreHP coreHP = other.GetComponent<CoreHP>();

            if(enemy != null)
            {
                enemy.TakeDamage(damagePerHit);
            }

            if(coreHP != null)
            {
                coreHP.TakeDamage(damagePerHit);
            }
        }
    }
}
