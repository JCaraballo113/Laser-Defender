﻿using UnityEngine;
using System.Collections;

public class ExplosionCleanup : MonoBehaviour 
{
    void Start()
    {
        Destroy(gameObject,1f);
    }
}
