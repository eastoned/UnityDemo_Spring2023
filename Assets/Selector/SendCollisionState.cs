using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCollisionState : MonoBehaviour
{
    
    public enum State{
        Falling,
        Rolling,
        Hit
    }

    public Texture[] reactions;

    public Renderer face;

    public State currentState;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Ground")){
            Debug.Log(transform.name + " has finished the race");
        }
    }

    void OnCollisionEnter(Collision col){
        Debug.Log(col.gameObject);
        face.material.SetTexture("_MainTex", reactions[Random.Range(0, reactions.Length)]);
        
    }
}
