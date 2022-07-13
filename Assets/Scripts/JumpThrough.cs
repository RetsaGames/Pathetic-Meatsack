using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThrough : MonoBehaviour
{
    Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fall"))
        {
            coll.enabled = false;
        }

        if (Input.GetButtonUp("Fall"))
        {
            coll.enabled = true;
        }
    }
}
