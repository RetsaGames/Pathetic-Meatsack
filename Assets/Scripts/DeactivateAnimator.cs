using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAnimator : MonoBehaviour
{

    [SerializeField] MonoBehaviour behaviorToActivate;
    public void deactivate()
    {
        GetComponent<Animator>().enabled = false;
        behaviorToActivate.enabled = true;
    }
}
