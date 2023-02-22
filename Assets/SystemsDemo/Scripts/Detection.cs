using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public List<GameObject> detectedObjects = new List<GameObject>();
    private SphereCollider col;

    void Start(){
        col = GetComponent<SphereCollider>();
    }

    private void Awake() {
        //subscribe to event
        GameManager.OnAgentCreated += UpdateDetectedObjects;
        GameManager.OnAgentDestroyed += UpdateDetectedObjects;
    }

    private void OnDisable() {
        //unsubscribe to prevent memory leaks/duplicate event calls
        GameManager.OnAgentCreated -= UpdateDetectedObjects;
        GameManager.OnAgentDestroyed -= UpdateDetectedObjects;
    }

    private void OnTriggerEnter(Collider other) {
        if(!detectedObjects.Contains(other.gameObject)){
            detectedObjects.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(detectedObjects.Contains(other.gameObject)){
            detectedObjects.Remove(other.gameObject);
        }
    }

    //run this everytime an object is deleted/spawned
    [ContextMenu("Test Offset")]
    private void UpdateDetectedObjects(){
        Debug.Log("Updating colliders in detections");
        detectedObjects.Clear();
        foreach(Collider collider in Physics.OverlapSphere(transform.position + transform.TransformVector(col.center), col.radius)){
            detectedObjects.Add(collider.gameObject);
        }
        
    }
}
