using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

    private MusicController theMusicController;

    public int newTrack;

    public bool SwitchOnStart;

	// Use this for initialization
	void Start () {
        theMusicController = FindObjectOfType<MusicController>();

        if (SwitchOnStart) {
            theMusicController.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player") {
            theMusicController.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
