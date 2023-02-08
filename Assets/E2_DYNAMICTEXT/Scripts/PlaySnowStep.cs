using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySnowStep : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    [SerializeField]
    private AudioClip run;
    private AudioSource source;

    void Start(){
        if(source == null)
            source = GetComponent<AudioSource>();
    }

    public void PlayRandomSnowStepClip(){
        if(!source.isPlaying){
            source.clip = clips[Random.Range(0, clips.Length)];
            source.pitch = Random.Range(0.5f, 0.8f);
            source.Play();
        }
            
    }

    public void PlaySnowRunClip(){
        if(!source.isPlaying){
            source.pitch = 1.5f;
            source.clip = run;
            source.Play();
        }
    }
}
