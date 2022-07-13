using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] LayerMask layerMask;

    Collider2D lastCollider;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f),0).normalized;
        rb.velocity = speed * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled)
            return;
        if (Util.isLayerInLayerMask(layerMask, collision.gameObject.layer))
        {
            if (collision == LimitManager.instance.topLimit)
            {
                rb.velocity = new Vector3(
                    rb.velocity.x,
                    -Mathf.Abs(rb.velocity.y),
                    0);
            }
            else if (collision == LimitManager.instance.leftLimit)
            {
                rb.velocity = new Vector3(
                    Mathf.Abs(rb.velocity.x),
                    rb.velocity.y,
                    0);
            }
            else if (collision == LimitManager.instance.bottomLimit)
            {
                rb.velocity = new Vector3(
                    rb.velocity.x,
                    Mathf.Abs(rb.velocity.y),
                    0);
            }
            else if (collision == LimitManager.instance.rightLimit)
            {
                rb.velocity = new Vector3(
                    -Mathf.Abs(rb.velocity.x),
                    rb.velocity.y,
                    0);
            }

            
        }
    }

}
