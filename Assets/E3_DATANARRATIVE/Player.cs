using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    [Range(0f, 5f)]
    public float amount, speed;

    [Range(0, 15)]
    public int sizeOfObject;

    public GameObject obj;
    public Vector3 Direction;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OscillateCube();
    }

    void OscillateCube(){
        
        
        timer += Time.deltaTime * speed;
        transform.position = amount * new Vector3(0, 0, 1) * Mathf.Sin(timer);
        
    }

 
    
}
