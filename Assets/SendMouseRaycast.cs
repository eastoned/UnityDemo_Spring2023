using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SendMouseRaycast : MonoBehaviour
{
    [SerializeField] private GameObject smallCylinder;
    private Camera thisCamera;

    private void Start() {
        thisCamera = GetComponent<Camera>();
    }

    private void Update(){
        
        if(Input.GetMouseButtonDown(1)){

            Ray ray = thisCamera.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 500f)){
                Debug.Log(hit.transform.gameObject.name);
                Instantiate(smallCylinder, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
            }
        }
    }
}
