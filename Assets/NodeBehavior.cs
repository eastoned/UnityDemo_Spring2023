using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehavior : MonoBehaviour
{
    void Start(){
        transform.GetComponent<Rigidbody>().mass = Random.Range(1f, 10f);
        transform.GetComponents<SphereCollider>()[1].radius = Random.Range(1f, 8f);
        transform.GetComponent<Rigidbody>().AddForce(Random.insideUnitCircle * 5f, ForceMode.Impulse);
    }
    private void OnTriggerStay(Collider other) {
        Debug.Log(other.transform.name);
        Vector3 diff = other.transform.position - transform.position;
        Debug.Log(diff);
        
        //transform.position = Vector3.MoveTowards(transform.position, other.transform.position, Time.deltaTime);
        transform.GetComponent<Rigidbody>().AddForce(diff/100f, ForceMode.Force);
    }
}
