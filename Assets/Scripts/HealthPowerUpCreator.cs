using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUpCreator : MonoBehaviour
{
    [Header("Prefab to instantiate")]
    [SerializeField] GameObject healthPowerUpPrefab;

    [Header("How far from the center the health pickups can be instantiated")]
    [SerializeField] float radius = 5;

    [Header("How much time does the first health pickup takes in appearing")]
    [SerializeField] float initialDelay = 15;

    [Header("Multiplies the previous delay so that health pickups are rarer as time passes")]
    [SerializeField] float multiplier = 1.5f;

    bool routineStarted = false;

    private void OnEnable()
    {
        Boss.OnBossDestroyed += onBossDead;
    }

    private void OnDisable()
    {
        Boss.OnBossDestroyed -= onBossDead;
    }

    void onBossDead()
    {
        if (routineStarted)
            return;

        routineStarted = true;
        StartCoroutine(powerUpCreator());
    }

    IEnumerator powerUpCreator()
    {
        while (true)
        {
            yield return new WaitForSeconds(initialDelay);
            initialDelay *= multiplier;
            Instantiate(healthPowerUpPrefab, new Vector3(
                Random.Range(-radius, radius),
                Random.Range(-radius, radius),
                0),
                Quaternion.identity);
        }
    }
}
