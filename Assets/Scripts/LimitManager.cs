using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitManager : MonoBehaviour
{
    public Collider2D topLimit;
    public Collider2D bottomLimit;
    public Collider2D leftLimit;
    public Collider2D rightLimit;

    public static LimitManager instance;

    private void Awake()
    {
        instance = this;
    }
}
