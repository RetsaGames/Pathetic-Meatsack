using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;

    [Header("Color to turn into when damaged")]
    [SerializeField] Color damageColor = Color.red;

    [Header("Speed of the damage effect fading out")]
    [SerializeField] float recoverSpeed = 1;

    [Header("Object to instantiate when damaged")]
    [SerializeField] GameObject bloodParticlePrefab;

    [Space]
    [SerializeField] AudioSource audioSource;

    SpriteRenderer[] sRenderers;
    //original colors of the sprite renderers
    Color[] sColors;

    // Start is called before the first frame update
    void Start()
    {
        sRenderers = GetComponentsInChildren<SpriteRenderer>();
        sColors = new Color[sRenderers.Length];
        for (int i = 0; i < sRenderers.Length; i++)
        {
            sColors[i] = sRenderers[i].color;
        }
    }

    private void Update()
    {
        //fade out the damage visual effect
        for (int i = 0; i < sRenderers.Length; i++)
        {
            sRenderers[i].color = 
                Color.Lerp(sRenderers[i].color,sColors[i],Time.deltaTime * recoverSpeed);
        }
    }

    /// <summary>
    /// Damage the enemy by a given amount
    /// </summary>
    public void damage(float amount)
    {
        health -= amount;
        if (audioSource)
            audioSource.Play();

        foreach (var sr in sRenderers)
        {
            sr.color = damageColor;
        }
        if (health < 0)
        {
            Instantiate(bloodParticlePrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public float getHealth()
    {
        return health;
    }

}
