﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*speed);
    }
}
