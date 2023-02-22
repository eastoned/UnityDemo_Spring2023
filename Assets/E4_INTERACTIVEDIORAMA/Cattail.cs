using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cattail : MonoBehaviour
{
    private LineRenderer stalk;
    private List<Vector3> stalkPoints = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        stalk = GetComponent<LineRenderer>();
        StartCoroutine(Grow());
    }

    IEnumerator Grow(){
        while(true){
            transform.Translate(new Vector3(0,0.05f,0));
            stalkPoints.Add(transform.position);
            Vector3[] stalkArray = stalkPoints.ToArray();
            stalk.positionCount = stalkArray.Length;
            stalk.SetPositions(stalkArray);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
