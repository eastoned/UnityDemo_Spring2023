using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListAmountController : MonoBehaviour
{
    public List<GameObject> inputFields = new List<GameObject>();

    public int playerCount => inputFields.Count;

    public GameObject inputFieldPrefab;

    public void AddToList(){
        GameObject newIF = Instantiate(inputFieldPrefab, Vector3.zero, Quaternion.identity, this.gameObject.transform);
        
        inputFields.Add(newIF);
        newIF.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inputFields.Count.ToString();
        newIF.transform.SetSiblingIndex(inputFields.Count);
    }

    public void RemoveFromList(){
        if(inputFields.Count > 0){
            GameObject oldIF = inputFields[inputFields.Count-1];
            oldIF.SetActive(false);
            inputFields.Remove(oldIF);
            Destroy(oldIF);
        }
    }

    public GameObject[] GetPlayerObjects(){
        return inputFields.ToArray();
    }
}
