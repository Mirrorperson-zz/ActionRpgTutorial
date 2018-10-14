using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text hpText;
    public Text levelText;
    public PlayerHealthManager playerHealth;
    private static bool uiExists;
    private PlayerStats playerStats;

    public Slider musicVolumeBar;
    public bool musicBarMinimized;
    public Button showVolumeButton;
    public MusicController theMusicController;

	// Use this for initialization
	void Start () {
        playerStats = GetComponent<PlayerStats>();
        theMusicController = FindObjectOfType<MusicController>();
        showVolumeButton = GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        hpText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        levelText.text = "Level: " + playerStats.currentLevel;
        
        theMusicController.volume = musicVolumeBar.value;
    }

    public void OnShowButton() {
        if (musicBarMinimized)
        {
            musicVolumeBar.animator.SetBool("ShowButton", true);
            musicVolumeBar.animator.SetBool("HideButton", false);
            musicBarMinimized = false;
        }
        else
        {
            musicVolumeBar.animator.SetBool("HideButton", true);
            musicVolumeBar.animator.SetBool("ShowButton", false);
            musicBarMinimized = true;
        }
    }
}
