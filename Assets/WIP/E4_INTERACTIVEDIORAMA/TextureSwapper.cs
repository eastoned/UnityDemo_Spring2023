using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwapper : MonoBehaviour
{
    [SerializeField] private MeshRenderer _me, _you;

    [SerializeField] private Texture _me1, _me2, _you1, _you2;


    void Start(){
        StartCoroutine(Blink(_me, _me2, _me1));
        StartCoroutine(Blink(_you, _you2, _you1));
    }
    [ContextMenu("Blink")]
    public void BlinkIt(){
        StartCoroutine("Blink", _me);
        
    }

    IEnumerator Blink(MeshRenderer rend, Texture blinkTex, Texture defTex){
        while(true){
            yield return new WaitForSeconds(Random.Range(1f, 8f));
            rend.sharedMaterial.SetTexture("_MainTex", blinkTex);
            yield return new WaitForSeconds(0.1f);
            rend.sharedMaterial.SetTexture("_MainTex", defTex);
        }
    }
}
