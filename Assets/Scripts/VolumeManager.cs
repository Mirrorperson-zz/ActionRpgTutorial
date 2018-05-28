﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

    public VolumeController[] vcObjects;
    public float currentVolumeLevel;
    public float maxVolumeLevel = 1.0f;

	// Use this for initialization
	void Start () {
        vcObjects = FindObjectsOfType<VolumeController>();

        if (currentVolumeLevel > maxVolumeLevel) {
            currentVolumeLevel = maxVolumeLevel;
        }

        foreach (VolumeController vc in vcObjects) {
            vc.SetAudioLevel(currentVolumeLevel);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
