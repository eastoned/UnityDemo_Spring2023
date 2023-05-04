using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject playerColliderPrefab;
    public GameObject playerNameTextPrefab;
    
    public List<Transform> colsToSend = new List<Transform>();
    public List<RectTransform> textsToSend = new List<RectTransform>();

    public List<RectTransform> UpdatePlayerTexts(string[] playerInfo){
        //Clear current list

        ClearRectTransform();

        for(int i = 0; i < playerInfo.Length; i++){
            //colsToSend.Add(Instantiate(playerColliderPrefab, Vector3.zero, Quaternion.identity).transform);
            Debug.Log("Spawned rect number:" + i);
            textsToSend.Add(Instantiate(playerNameTextPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<RectTransform>());
        }

        return textsToSend;

    }

    public List<Transform> UpdatePlayerColliders(string[] playerInfo){
        //Clear current list

        ClearTransform();

        for(int i = 0; i < playerInfo.Length; i++){
            Debug.Log("Spawned transform number:" + i);
            colsToSend.Add(Instantiate(playerColliderPrefab, new Vector3(Random.Range(-2f, 2f), Random.Range(12f, 15f), 0), Quaternion.Euler(90, 0, 0)).transform);
            colsToSend[i].GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
            colsToSend[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //textsToSend.Add(Instantiate(playerNameTextPrefab, Vector3.zero, Quaternion.identity).GetComponent<RectTransform>());
        }

        //cols = colsToSend;
        return colsToSend;

    }

    public void ClearTransform(){
        for(int i = colsToSend.Count-1; i > -1; i--){
            Transform delObj = colsToSend[i];
            colsToSend.Remove(delObj);
            Destroy(delObj.gameObject);
            Debug.Log("Deleted transform number:" + i);
        }
    }

    public void ClearRectTransform(){
        for(int i = colsToSend.Count-1; i > -1; i--){
            RectTransform delObj = textsToSend[i];
            textsToSend.Remove(delObj);
            Destroy(delObj.gameObject);
            Debug.Log("Deleted rect number:" + i);
        }
    }
}
