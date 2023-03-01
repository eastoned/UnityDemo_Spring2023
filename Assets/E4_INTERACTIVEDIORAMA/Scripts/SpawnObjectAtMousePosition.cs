using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectAtMousePosition : MonoBehaviour
{
    public GameObject prefab, prefab1;
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
                
                //Instantiate(prefab1, hit.point, Quaternion.FromToRotation(prefab.transform.up, hit.normal));
                //GameObject flippedCat = Instantiate(prefab1, hit.point, Quaternion.Euler(180, 180, 180) * Quaternion.FromToRotation(prefab.transform.up, -hit.normal));
                //flippedCat.GetComponent<Cattail>().SetFlipped();
            }
        }
    }

    void SpawnCattail(){

    }
}
