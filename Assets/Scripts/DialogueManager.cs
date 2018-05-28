using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    // Add delay between show and hide
    public float dHideCooldown;
    public float dShowCooldown;

    public bool dialogueActive;
    public string[] dialogueLines;
    public int currentLine;

    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dHideCooldown <= 0)
        {
            if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;
            }

            if (currentLine >= dialogueLines.Length) {
                dBox.SetActive(false);
                dialogueActive = false;
                currentLine = 0;
                dShowCooldown = 0.5f;
                thePlayer.canMove = true;
            }

            dText.text = dialogueLines[currentLine];
        }
        else
        {
            dHideCooldown -= Time.deltaTime;
        }
	}

    //public void ShowBox(string dialogue) {
    //    dialogueActive = true;
    //    dBox.SetActive(true);
    //    dText.text = dialogue;
    //}

    public void ShowDialogue() {
        dialogueActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
