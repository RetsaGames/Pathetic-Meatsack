using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float hitDamage = 1;
    [SerializeField] bool destroyOnTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerHealth.instance && collision.gameObject == PlayerHealth.instance.gameObject)
        {
            PlayerHealth.instance.damage(hitDamage);
            if (destroyOnTouch)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerHealth.instance && collision.gameObject == PlayerHealth.instance.gameObject)
        {
            PlayerHealth.instance.damage(hitDamage);
            if (destroyOnTouch)
            {
                Destroy(gameObject);
            }
        }
    }
}
