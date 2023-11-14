using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript1 : MonoBehaviour
{
    public int musID;
    public AudioClip[] tracks;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = false;
        PlayCurrentTrack();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            NextTrack();
        }
    }

    void PlayCurrentTrack()
    {
        if (tracks.Length > 0 && musID < tracks.Length)
        {
            audioSource.clip = tracks[musID];
            audioSource.Play();
        }
    }

    public void NextTrack()
    {
        musID++;
    }

}
