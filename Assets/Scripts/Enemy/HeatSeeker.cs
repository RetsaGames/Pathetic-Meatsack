using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSeeker : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed=1;
    [SerializeField] float acceleration = 1;
    
    void Update()
    {
        if (PlayerHealth.instance)
        {
            Vector3 direction = (PlayerHealth.instance.transform.position - transform.position).normalized;
            rb.velocity = Vector3.Lerp(rb.velocity,direction * speed,Time.deltaTime * acceleration);
            transform.right = rb.velocity;
        }
        
    }

    public void setVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }
}
