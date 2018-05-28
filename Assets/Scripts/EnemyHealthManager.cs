using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;
    public string enemyQuestName;

    private QuestManager theQuestManager;
    private PlayerStats playerStats;

    public int expToGive;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;

        playerStats = FindObjectOfType<PlayerStats>();
        theQuestManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            theQuestManager.enemyKilled = enemyQuestName;

            Destroy(gameObject);
            playerStats.AddExperience(expToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}