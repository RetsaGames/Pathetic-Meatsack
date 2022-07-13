using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public static System.Action<float> OnDamaged = (newHealth) => { };
    public static System.Action<float> OnHealthChanged = (newHealth) => { };
    public static System.Action onDeath = () =>{};

    [SerializeField] float health = 100;

    [Header("Blinking effect when damaged, temporary invunerability")]
    [SerializeField] Blink blink;

    [Header("Prefab to instantiate when damaged")]
    [SerializeField] GameObject bloodParticlePrefab;

    [Space]
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Damage the player by a given amount
    /// </summary>
    public void damage(float amount)
    {
        if (blink.isBlinking())
            return;
        audioSource.Play();
        health -= amount;
        blink.blink();
        OnDamaged(health);

        if (health <= 0)
        {
            Instantiate(bloodParticlePrefab,transform.position,Quaternion.identity);
            onDeath();
            Destroy(gameObject);
        }
    }

    public float getHealth()
    {
        return health;
    }

    /// <summary>
    /// Heals 1 health point
    /// </summary>
    public void addHealthPoint()
    {
        health++;
        OnHealthChanged(health);
    }
}
