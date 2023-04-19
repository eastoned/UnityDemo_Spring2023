using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Agent
{
    public bool inDanger;

    private void OnCollisionEnter(Collision other) {
        
        Debug.Log(transform.name + " collided with: " + other.collider.name);
        if(other.collider.CompareTag("Cat")){
            Debug.Log("Eaten");
            Die();
        }
        if(other.collider.CompareTag("Mouse")){
            Debug.Log("Spawns");
        }
        if(other.collider.CompareTag("Cheese")){
            Debug.Log("Eats");
        }
   }
}
