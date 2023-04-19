using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Agent : MonoBehaviour
{
    public float normalSpeed, runSpeed;
    private Rigidbody rb;
    
    //could optimize through using physics.overlapsphere, but for clarity we'll use an explicit collider

    public float hungerAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Eat(){

    }

    public void Push(Vector3 direction, float force){
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    public void Spawn(){
        GameManager.Instance.CreateObject(this.gameObject.name);
    }

    public void Die(){
        GameManager.Instance.DestroyAgent(this.gameObject);
    }

}
