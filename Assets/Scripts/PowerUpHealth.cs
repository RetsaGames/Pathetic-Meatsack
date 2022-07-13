using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerHealth.instance && collision.gameObject == PlayerHealth.instance.gameObject)
        {
            if (PlayerHealth.instance.getHealth() < 3)
            {
                PlayerHealth.instance.addHealthPoint();
                Destroy(gameObject);
            }
        }
    }
}
