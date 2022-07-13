using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [Header("Sprite for the damage effect")]
    [SerializeField] SpriteRenderer damageSprite;

    [Header("Sprite for the healing effect")]
    [SerializeField] SpriteRenderer healSprite;

    [Header("Sprite color for the damage effect")]
    [SerializeField] Color damageColor;

    [Header("Sprite color for the healing effect")]
    [SerializeField] Color healColor;

    [Header("Speed of the effects turning off")]
    [SerializeField] float recoverSpeed = 3;
    
    [Header("Sound to play when healed")]
    [SerializeField] AudioClip healthSound;
    [SerializeField] AudioSource audioSource;


    private void OnEnable()
    {
        PlayerHealth.OnDamaged += onPlayerDamaged;
        PlayerHealth.OnHealthChanged += onPlayerHealed;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDamaged -= onPlayerDamaged;
        PlayerHealth.OnHealthChanged -= onPlayerHealed;
    }

    private void Update()
    {
        //Reduce damage visual effect
        Color targetDamageColor = new Color(
            damageColor.r, damageColor.g, damageColor.b,0);
        damageSprite.color = Color.Lerp(damageSprite.color, targetDamageColor, Time.deltaTime * recoverSpeed);

        //Reduce healing visual effect
        Color targetHealColor = new Color(
            healColor.r, healColor.g, healColor.b, 0);
        healSprite.color = Color.Lerp(healSprite.color, targetHealColor, Time.deltaTime * recoverSpeed);
    }

    //turn on damage effect
    void onPlayerDamaged(float playerHealth)
    {
        damageSprite.color = damageColor;
    }

    //turn on healing effect and play sound
    void onPlayerHealed(float playerHealth)
    {
        audioSource.PlayOneShot(healthSound);
        healSprite.color = healColor;
    }
}
