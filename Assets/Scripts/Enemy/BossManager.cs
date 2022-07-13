using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] GameObject[] bossPrefabs;

    [Header("Current boss")]
    [SerializeField] int currentIndex = 0;

    [Header("Resting time between bosses")]
    [SerializeField] float delay;

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
        currentIndex++;
        if (currentIndex >= bossPrefabs.Length)
            currentIndex = 0;
        StartCoroutine(spawnBoss());
    }

    IEnumerator spawnBoss()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(bossPrefabs[currentIndex]);
    }

}
