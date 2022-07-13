using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static bool isLayerInLayerMask(this LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
