using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replicas : MonoBehaviour
{
    public int musID;
    public AudioClip[] tracks;
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
        AudioClip audioClip = Resources.Load<AudioClip>(); // ��������� ��������� �� ����� Resources
        if (audioClip != null)
        {
            GameObject audioSourceGo = new GameObject("AudioSource"); // ������� ����� ������ ��� AudioSource
            AudioSource audioSource = audioSourceGo.AddComponent<AudioSource>(); // ��������� ��������� AudioSource � ������ �������

            audioSource.clip = audioClip; // ����������� ����������� ��������� ������� AudioSource
            audioSource.Play(); // ��������� ������������ �����
        }
        else
        {
            Debug.Log("��������� �� ������.");
        }
    }

}
