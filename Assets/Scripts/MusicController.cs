using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class MusicController : MonoBehaviour {

    public static bool mcExists;

    public AudioSource[] musicTracks;

    private int currentTrack;

    public bool musicCanPlay;

    public float volume;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying) {
                foreach (AudioSource source in musicTracks) {
                    source.Stop();
                }
                
                musicTracks[currentTrack].Play();
            }
        } else {
            musicTracks[currentTrack].Stop();
        }
	}

    public void SwitchTrack(int newTrack) {
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }

    public void OnMusicVolumeChange(float sliderValue) {
        volume = sliderValue;
        musicTracks[currentTrack].volume = volume;
    }
}