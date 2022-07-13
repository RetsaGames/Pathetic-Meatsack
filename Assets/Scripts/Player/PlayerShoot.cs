using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Player's gun that rotates towards mouse")]
    [SerializeField] GameObject playerArm;

    [Header("Handles gun spinning animation")]
    [SerializeField] Animator gunAnimator;

    [Header("Proyectile origin")]
    [SerializeField] GameObject muzzle;

    [Space]
    [SerializeField] GameObject proyectilePrefab;

    [Space]
    [SerializeField] float proyectileSpeed;

    [Space]
    [SerializeField] float timeBetweenShots;

    [Header("shoot max deviation from the target")]
    [SerializeField] float dispersion = 0.1f;

    [SerializeField] AudioSource audioSource;

    bool canShoot = true;


    void Update()
    {

        if (Input.GetButton("Fire")){
            if (canShoot)
            {
                audioSource.Play();
                GameObject proyectile =
                    Instantiate(proyectilePrefab, muzzle.transform.position, Quaternion.identity);
                Vector3 direction = playerArm.transform.up.normalized;
                Vector3 directionDispersion = new Vector3(
                    direction.x+Random.Range(-dispersion,dispersion),
                    direction.y + Random.Range(-dispersion, dispersion),
                    direction.z).normalized;
                proyectile.GetComponent<Rigidbody2D>().velocity = directionDispersion * proyectileSpeed;
                canShoot = false;
                StartCoroutine(reload());
            }
            
            gunAnimator.SetBool("shooting", true);
        }
        else
        {
            gunAnimator.SetBool("shooting", false);
        }
        
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
}
