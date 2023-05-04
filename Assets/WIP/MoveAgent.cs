using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private NavMeshAgent agent;
    private CharacterController control;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 500f, ~LayerMask.NameToLayer("Default"))){
                agent.SetDestination(hit.point);
                
            }
        }
    }
}
