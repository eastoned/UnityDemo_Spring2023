using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cattail : MonoBehaviour
{
    private LineRenderer stalk;
    private List<Vector3> stalkPoints = new List<Vector3>();
    private float originPoint;
    private bool flipped = false;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        stalk = GetComponent<LineRenderer>();
        lifetime = Random.Range(5f, 5f);
        originPoint = transform.position.x * transform.position.z;
        StartCoroutine(Grow());
    }

    public void SetFlipped(){
        flipped = true;
    }

    IEnumerator Grow(){
        while(lifetime > 0){
            if(!flipped){
                transform.Rotate((Mathf.PerlinNoise(Time.time * .1f, originPoint) - 0.5f) * (Vector3.one - Vector3.up), Space.World);
            }else{
                transform.Rotate(-(Mathf.PerlinNoise(Time.time * .1f, originPoint) - 0.5f) * (Vector3.one - Vector3.up), Space.World);
            }
            transform.Translate(Vector3.up * 0.01f, Space.Self);
            stalkPoints.Add(transform.position);
            Vector3[] stalkArray = stalkPoints.ToArray();
            stalk.positionCount = stalkArray.Length;
            stalk.SetPositions(stalkArray);
            lifetime -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        stalk.Simplify(.005f);
    }
}
