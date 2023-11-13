using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarScript : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayTrack()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();

    }

 

}
