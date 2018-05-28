using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dManager;
    public string[] dialogueLines;

	// Use this for initialization
	void Start () {
        dManager = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dManager.dShowCooldown > 0) {
            dManager.dShowCooldown -= Time.deltaTime;
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space) && dManager.dShowCooldown <= 0 && !dManager.dialogueActive) {
                
                if (!dManager.dialogueActive) {
                    dManager.dialogueLines = dialogueLines;
                    dManager.currentLine = 0;
                    dManager.ShowDialogue();
                }

                if (transform.parent.GetComponent<NpcMovement>() != null) {
                    transform.parent.GetComponent<NpcMovement>().canMove = false;
                }
            }
        }
    }
}
