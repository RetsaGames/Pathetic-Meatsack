using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProyectile : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float timeToDie;
    [SerializeField] float damage = 1;
    
    void Start()
    {
        StartCoroutine(waitNDie());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Util.isLayerInLayerMask(targetLayer, collision.gameObject.layer))
        {
            collision.gameObject
                .GetComponentInParent<EnemyHealth>().damage(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator waitNDie()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }
}
