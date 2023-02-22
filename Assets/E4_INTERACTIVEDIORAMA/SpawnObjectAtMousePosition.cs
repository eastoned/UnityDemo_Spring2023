using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectAtMousePosition : MonoBehaviour
{
    public GameObject prefab;
    public Camera cam;

    void Start(){
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f)){
                GameObject spawn = Instantiate(prefab, hit.point + (hit.normal*0.1f), Quaternion.FromToRotation(prefab.transform.up, hit.normal));
                
            }
        }
    }
}
