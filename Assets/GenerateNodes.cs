using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNodes : MonoBehaviour
{
    public GameObject node;
    public Vector3[] positions;
    public int nodeCount;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSpheres();
        GenerateConnections();
    }
    void Update() {
        GenerateConnections();    
    }

    void GenerateSpheres(){
        positions = new Vector3[nodeCount];
        for(int i = 0; i < nodeCount; i++){
            positions[i] = 10f*Random.insideUnitCircle;
            Instantiate(node, positions[i], Quaternion.identity);
        }
    }

    void GenerateConnections(){
        Debug.DrawLine(positions[0], positions[1]);
        Debug.DrawLine(positions[1], positions[3]);
        Debug.DrawLine(positions[4], positions[5]);

    }
}
