using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SendMouseRaycast : MonoBehaviour
{
    //[SerializeField] private GameObject smallCylinder;
    private Camera thisCamera;

    public delegate void ClickLink(string tag);
    public static event ClickLink LinkClicked;

    private void Start() {
        thisCamera = GetComponent<Camera>();
    }

    private void Update(){
        
        if(Input.GetMouseButtonDown(0)){

            Ray ray = thisCamera.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 500f)){
                Debug.Log(hit.transform.tag);
                LinkClicked(hit.transform.tag);
            }
        }
    }
}
