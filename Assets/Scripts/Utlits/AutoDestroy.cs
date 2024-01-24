using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private void Awake()
    {
        Destroy(this.gameObject, 1f);
    }
}
