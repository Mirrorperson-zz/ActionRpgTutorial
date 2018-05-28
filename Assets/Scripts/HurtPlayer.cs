using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageNumber;
    private PlayerStats thePlayerStats;

    // Use this for initialization
    void Start () {
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            currentDamage = damageToGive - thePlayerStats.currentDefense;
            if (currentDamage <= 0) {
                currentDamage = 1;
            }

            PlayerHealthManager playerHealthManager = other.gameObject.GetComponent<PlayerHealthManager>();

            if (!playerHealthManager.flashActive) {
                playerHealthManager.HurtPlayer(currentDamage);
                var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingNumbers>().displayNumber.color = Color.red;
                clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            }
        }
    }
}
