using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnect : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject destiny;
    
    void Update()
    {
        lineRenderer.SetPositions(new Vector3[]{
            transform.position,
            destiny.transform.position
        });
    }
}
