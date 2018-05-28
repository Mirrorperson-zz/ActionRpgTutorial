using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;
    public bool flashActive;
    public float flashLength;
    public float flashCounter;
    private SpriteRenderer playerSprite;
    private SFXManager sfxManager;

    // Use this for initialization
    void Start () {
        playerCurrentHealth = playerMaxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
        sfxManager = FindObjectOfType<SFXManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerCurrentHealth <= 0) {
            sfxManager.PlaySound("dead");
            gameObject.SetActive(false);
        }

        if (flashActive) {
            if (flashCounter > flashLength * 0.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }

            if (flashCounter < 0) {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
	}

    public void HurtPlayer(int damageToGive) {
        if (!flashActive) {
            playerCurrentHealth -= damageToGive;
            flashActive = true;
            flashCounter = flashLength;
            sfxManager.PlaySound("hurt");
        }
    }

    public void SetMaxHealth() {
        playerCurrentHealth = playerMaxHealth;
    }
}
