using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILives : MonoBehaviour
{
    //lives image
    [SerializeField] Image lives;

    //width of the lives image
    float originalLivesWidth;

    void OnEnable()
    {
        PlayerHealth.OnDamaged += OnPlayerhealthChanged;
        PlayerHealth.OnHealthChanged += OnPlayerhealthChanged;
    }

    void OnDisable()
    {
        PlayerHealth.OnDamaged -= OnPlayerhealthChanged;
        PlayerHealth.OnHealthChanged -= OnPlayerhealthChanged;
    }

    void Start()
    {
        originalLivesWidth = lives.rectTransform.sizeDelta.x;
        
        lives.rectTransform.sizeDelta = new Vector2(
            originalLivesWidth * PlayerHealth.instance.getHealth(),
            lives.rectTransform.sizeDelta.y
            );
    }
    
    void OnPlayerhealthChanged(float livesLeft)
    {
        lives.rectTransform.sizeDelta = new Vector2(
            originalLivesWidth * livesLeft,
            lives.rectTransform.sizeDelta.y
            );
    }
}
