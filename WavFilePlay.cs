using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WavFilePlay : MonoBehaviour
{
    // Start is called before the first frame update
    private List<AudioClip> audioclip_list = new List<AudioClip>();
    public AudioClip sound1;
    AudioSource audioSource;
    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource> ();
        for (int i = 0; i < UnityMicRecording.filepath_list.Count; i++)
        {
            audioclip_list.Add(WavUtility.ToAudioClip(UnityMicRecording.filepath_list[i]));
            Debug.Log("audioclip_list " + audioclip_list[i]);
            Debug.Log("i " + i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void Onplay1()
    {
        audioSource.clip = audioclip_list[0];
        audioSource.Play ();
    }
    public void Onplay2()
    {
        audioSource.clip = audioclip_list[1];
        audioSource.Play ();
    }
    public void Onplay3()
    {
        audioSource.clip = audioclip_list[2];
        audioSource.Play ();
    }
    public void Onplay4()
    {
        audioSource.clip = audioclip_list[3];
        audioSource.Play ();
    }
    public void Onplay5()
    {
        audioSource.clip = audioclip_list[4];
        audioSource.Play ();
    }
}
