using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public int questNumber;
    public QuestManager theQuestManager;
    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;

    public bool isKillQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKilled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isItemQuest) {
            if (theQuestManager.itemCollected == targetItem) {
                theQuestManager.itemCollected = null;
                EndQuest();
            }
        } else if (isKillQuest) {
            if (theQuestManager.enemyKilled == targetEnemy) {
                theQuestManager.enemyKilled = null;
                enemyKilled += 1;

                if (enemyKilled >= enemiesToKill) {
                    EndQuest();
                }
            }
        }
	}

    public void StartQuest() {
        theQuestManager.ShowQuestText(startText);
    }

    public void EndQuest() {
        theQuestManager.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
        theQuestManager.ShowQuestText(endText);
    }
}
