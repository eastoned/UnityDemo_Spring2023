using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Saw: " + other.transform.name);
    }
    private void OnTriggerExit(Collider other) {
        Debug.Log("Can no longer see: " + other.transform.name);
    }
    
}
