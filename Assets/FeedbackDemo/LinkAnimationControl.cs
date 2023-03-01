using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkAnimationControl : MonoBehaviour
{
    private Animator linkAnim;

    [SerializeField] private Slider health;
    [SerializeField] private GameObject splatter;
    [SerializeField] private AudioSource yelp;

    [SerializeField] private CameraShake shake;

    public float linkHealth = 50f;

    void Start(){
        linkAnim = GetComponent<Animator>();
    }

    void OnEnable(){
        SendMouseRaycast.LinkClicked += TriggerAnimation;
    }
    void OnDisable(){
        SendMouseRaycast.LinkClicked -= TriggerAnimation;
    }

    void TriggerAnimation(string tag){
        Debug.Log(tag);
        
        yelp.PlayOneShot(yelp.clip);

        if(linkHealth >= 0){
            linkAnim.SetTrigger(tag);
            UpdateHealthUI(linkHealth - Random.Range(5f, 15f));
        }else{
            linkAnim.SetTrigger("Knocked");
            UpdateHealthUI(50f);
        }
        
    }

    void UpdateHealthUI(float newHealth){
        linkHealth = newHealth;
        health.value = linkHealth/50f;
        
    }

}
