using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
    public int[] hpLevels;
    public int[] attackLevels;
    public int[] defenseLevels;
    public int currentHp;
    public int currentAttack;
    public int currentDefense;
    private PlayerHealthManager thePlayerHealth;

	// Use this for initialization
	void Start () {
        currentHp = hpLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];
        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();

        // Set health according to stats at start
        thePlayerHealth.playerMaxHealth = currentHp;
        thePlayerHealth.SetMaxHealth();
    }

    // Update is called once per frame
    void Update() {
        if (currentExp >= toLevelUp[currentLevel]) {
            LevelUp();
        }
	}

    public void AddExperience(int experienceToAdd) {
        currentExp += experienceToAdd;
    }

    public void LevelUp() {
        currentLevel += 1;
        currentHp = hpLevels[currentLevel];
        thePlayerHealth.playerMaxHealth = currentHp;
        thePlayerHealth.playerCurrentHealth += currentHp - hpLevels[currentLevel - 1];
        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];
    }
}
