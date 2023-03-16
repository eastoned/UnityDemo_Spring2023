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
        if(Input.GetMouseButtonDown(1)){
            RaycastHit hit;
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f)){
                //GameObject spawn = Instantiate(prefab, hit.point + (hit.normal*0.1f), Quaternion.FromToRotation(prefab.transform.up, hit.normal));
                
                GameObject cat = Instantiate(prefab1, hit.point, Quaternion.FromToRotation(prefab.transform.up, hit.normal));
                cat.transform.localScale *= Mathf.Log(Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero), 3)+1;
                cat.GetComponent<Cattail>().SetWidth = Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero)/40f;
                cat.GetComponent<Cattail>().SetLifetime = Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero);
                if(hit.transform.CompareTag("Ground")){
                    GameObject flippedCat = Instantiate(prefab1, hit.point, Quaternion.Euler(180, 180, 180) * Quaternion.FromToRotation(prefab.transform.up, -hit.normal));
                    flippedCat.GetComponent<Cattail>().SetFlipped();
                    
                    flippedCat.transform.localScale *= Mathf.Log(Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero), 3)+1;
                    flippedCat.GetComponent<Cattail>().SetWidth = Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero)/40f;
                    flippedCat.GetComponent<Cattail>().SetLifetime = Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero);
                }else{
                    GameObject flippedCat = Instantiate(prefab1, new Vector3(hit.point.x, -hit.point.y, hit.point.z), Quaternion.Euler(180, 180, 180) * Quaternion.FromToRotation(prefab.transform.up, hit.normal));
                    flippedCat.GetComponent<Cattail>().SetFlipped();
                    
                    flippedCat.transform.localScale *= Mathf.Log(Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero), 3)+1;
                    flippedCat.GetComponent<Cattail>().SetWidth = Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero)/40f;
                    flippedCat.GetComponent<Cattail>().SetLifetime = Vector2.Distance(new Vector2(hit.point.x, hit.point.z), Vector2.zero);
                }
            }
        }
    }

    void SpawnCattail(){

    }
}
