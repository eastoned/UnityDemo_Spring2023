using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipMesh : MonoBehaviour
{

    MeshFilter mf;
    MeshRenderer mr;
    MeshCollider mc;

    public Vector3[] verts;
    void Start()
    {
        mf = GetComponent<MeshFilter>();

        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f)){
                Debug.Log(hit.triangleIndex);
                Mesh mesh = new Mesh();
                mesh.vertices = mf.sharedMesh.vertices;
                mesh.normals = mf.sharedMesh.normals;
                mesh.triangles = mf.sharedMesh.triangles;
                mesh.uv = mf.sharedMesh.uv;
                mesh.name = "Cloned Mesh";

                Mesh slicedMesh = new Mesh();
                //normals[triangles[hit.triangleIndex * 3 + 0]]
                verts = new Vector3[]{transform.TransformPoint
                (mesh.vertices[mesh.triangles[hit.triangleIndex * 3 + 0]]),
                transform.TransformPoint
                (mesh.vertices[mesh.triangles[hit.triangleIndex * 3 + 1]]),
                transform.TransformPoint
                (mesh.vertices[mesh.triangles[hit.triangleIndex * 3 + 2]])};

                slicedMesh.vertices = new Vector3[]{mesh.vertices[mesh.triangles[hit.triangleIndex * 3 + 0]],mesh.vertices[mesh.triangles[hit.triangleIndex * 3 + 1]],mesh.vertices[mesh.triangles[hit.triangleIndex * 3 + 2]]};
                List<int> tris = new List<int>(mesh.triangles);
                //List<Vector3> vertis = new List<Vector3>(mesh.vertices);
                
                tris.RemoveAt(hit.triangleIndex * 3 + 2);
                tris.RemoveAt(hit.triangleIndex * 3 + 1);
                tris.RemoveAt(hit.triangleIndex * 3 + 0);

                slicedMesh.normals = new Vector3[]{mesh.normals[mesh.triangles[hit.triangleIndex * 3 + 0]],mesh.normals[mesh.triangles[hit.triangleIndex * 3 + 1]],mesh.normals[mesh.triangles[hit.triangleIndex * 3 + 2]]};
                slicedMesh.triangles = new int[]{0, 1, 2};
                slicedMesh.name = "Sliced Mesh";
                GameObject piece = new GameObject("Piece");
                piece.transform.SetPositionAndRotation(transform.position, transform.rotation);
                piece.transform.localScale = transform.localScale;
                
                MeshFilter mf2 = piece.AddComponent<MeshFilter>();
                piece.AddComponent<MeshRenderer>().materials = mr.materials;
                mf2.sharedMesh = slicedMesh;
                //mesh.vertices = vertis.ToArray();
                mesh.triangles = tris.ToArray();
                piece.SetActive(false);
                mf.sharedMesh = mesh;
                mc.sharedMesh = mesh;
            }
        }
    }

    void OnDrawGizmosSelected(){
        if(verts.Length > 0){
        for(int i = 0; i < verts.Length; i++){
            Gizmos.DrawWireSphere(verts[i], 0.2f);
        }}
    }
}
