﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCoinScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Box(new Rect(700, 25, 100, 100), "Coins");
    }
}
