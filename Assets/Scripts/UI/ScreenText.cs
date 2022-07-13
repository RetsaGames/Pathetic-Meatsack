using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    bool firstBossKilled = false;

    private void OnEnable()
    {
        Boss.OnBossDestroyed += OnBossKilled;
        PlayerHealth.onDeath += OnPlayerKilled;

    }

    private void OnDisable()
    {
        Boss.OnBossDestroyed -= OnBossKilled;
        PlayerHealth.onDeath -= OnPlayerKilled;
    }

    void OnBossKilled()
    {
        if (!firstBossKilled)
        {
            firstBossKilled = true;
            text.text = " ";
        }
    }

    void OnPlayerKilled()
    {
        text.text = "you died, as expected. \n Press Space or Return to continue";
    }
}
