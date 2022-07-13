using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSeekerShoot : MonoBehaviour
{
    [SerializeField] GameObject[] shootingOrigins;
    [SerializeField] Vector3[] possibleDirections;
    [SerializeField] GameObject heatSeekerPrefab;

    public void attack()
    {
        foreach (var o in shootingOrigins)
        {
            Vector3 direction = possibleDirections[Random.Range(0, possibleDirections.Length)];
            GameObject hs =Instantiate(heatSeekerPrefab, o.transform.position, Quaternion.identity);
            if (hs.GetComponent<HeatSeeker>())
                hs.GetComponent<HeatSeeker>().setVelocity(direction);

        }
    }
}
