﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public float rotateSpeed = 2f;

	void Update () {

        transform.Rotate(new Vector3(0f, 0f, rotateSpeed));    
    }
}
