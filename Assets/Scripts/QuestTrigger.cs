using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

    private QuestManager theQuestManager;
    public int questNumber;
    public bool startQuest;
    public bool endQuest;

	// Use this for initialization
	void Start () {
        theQuestManager = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if(!theQuestManager.questCompleted[questNumber])
            {
                if (startQuest && !theQuestManager.quests[questNumber].gameObject.activeSelf)
                {
                    theQuestManager.quests[questNumber].gameObject.SetActive(true);
                    theQuestManager.quests[questNumber].StartQuest();
                } else if (endQuest && theQuestManager.quests[questNumber].gameObject.activeSelf) {
                    theQuestManager.quests[questNumber].EndQuest();
                }
            }
        }
    }
}
