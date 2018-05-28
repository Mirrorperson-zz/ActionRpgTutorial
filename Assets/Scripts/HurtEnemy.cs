﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform pointOfHit;
    public GameObject damageNumber;
    private PlayerStats thePlayerStats;

	// Use this for initialization
	void Start () {
        thePlayerStats = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            currentDamage = damageToGive + thePlayerStats.currentAttack;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, pointOfHit.position, transform.rotation);
            var clone = (GameObject) Instantiate(damageNumber, pointOfHit.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}