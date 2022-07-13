using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIKills : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtKills;

    int kills = 0;

    private void OnEnable()
    {
        Boss.OnBossDestroyed += OnBossDestroyed;
    }

    private void OnDisable()
    {
        Boss.OnBossDestroyed -= OnBossDestroyed;
    }

    void OnBossDestroyed()
    {
        kills++;
        txtKills.text = "Kills: " + kills;
    }
}
