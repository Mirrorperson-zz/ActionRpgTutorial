using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioSource[] audioSources;
    public Dictionary<string, int> audioIndexesMap;

    private static bool sfxManagerExists;

    // Use this for initialization
    void Start () {
        if (!sfxManagerExists)
        {
            sfxManagerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Set up audioIndexesMap
        audioIndexesMap = new Dictionary<string, int>();
        int indexCounter = 0;
        foreach (AudioSource audio in audioSources) {
            audioIndexesMap.Add(audio.name, indexCounter);
            indexCounter += 1;
        }
    }

    public void PlaySound(string audioName) {
        int index;
        bool foundAudio = audioIndexesMap.TryGetValue(audioName, out index);
        if (foundAudio) {
            audioSources[index].Play();
        }
    }
}
