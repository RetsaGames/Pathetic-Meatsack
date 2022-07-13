using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static System.Action<GameObject> OnBossCreated;
    public static System.Action OnBossDestroyed;

    EnemyHealth enemyHealth;

    void Start()
    {
        OnBossCreated(gameObject);
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnDestroy()
    {
        if (enemyHealth.getHealth()<=0)
            OnBossDestroyed();
    }
}
