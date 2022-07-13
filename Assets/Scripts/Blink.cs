using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [Header("Blinking duration")]
    [SerializeField] float blinkingTime;

    [Header("Time between turning on and off sprites")]
    [SerializeField] float blinkInterval;

    bool blinking;
    SpriteRenderer[] sRenderers;
    
    void Start()
    {
        sRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    /// <summary>
    /// Start the blinking effect
    /// </summary>
    public void blink()
    {
        if (!blinking)
        {
            StartCoroutine(blinkingRoutine());
        }
        
    }

    //routine handling the turning on and off of sprites
    IEnumerator blinkingRoutine()
    {
        blinking = true;
        float timeLeft = blinkingTime;
        bool turnedOn = false;
        while (timeLeft > 0)
        {
            foreach (var sr in sRenderers)
                sr.enabled = turnedOn;

            yield return new WaitForSeconds(blinkInterval);
            timeLeft -= blinkInterval;
            turnedOn = !turnedOn;
        }
        foreach (var sr in sRenderers)
            sr.enabled = true;
        blinking = false;
    }

    public bool isBlinking()
    {
        return blinking;
    }
}
