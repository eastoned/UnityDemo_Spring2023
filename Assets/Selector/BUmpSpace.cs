using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUmpSpace : MonoBehaviour
{

    private Vector3 originalPos;

    void Start(){
        originalPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            transform.position = originalPos + new Vector3(0, 1f, 0);
        }else{
            transform.position = originalPos;
        }

    }
}
