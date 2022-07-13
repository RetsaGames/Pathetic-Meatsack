using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;

    EnemyHealth enemyHealth;

    float originalWidth;
    float originalHealth;

    private void OnEnable()
    {
        Boss.OnBossCreated += OnBossCreated;
    }

    private void OnDisable()
    {
        Boss.OnBossCreated -= OnBossCreated;
    }

    private void Start()
    {
        originalWidth = healthBar.transform.localScale.y;
    }

    void OnBossCreated(GameObject boss)
    {
        enemyHealth = boss.GetComponent<EnemyHealth>();
        originalHealth = enemyHealth.getHealth();
    }

    private void Update()
    {
        if (enemyHealth)
        {
            healthBar.transform.localScale = new Vector3(
                healthBar.transform.localScale.x,
                originalWidth * (enemyHealth.getHealth()/originalHealth),
                healthBar.transform.localScale.z);
        }
    }
}
