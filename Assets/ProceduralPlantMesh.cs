using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ProceduralPlantMesh : MonoBehaviour
{

    private MeshFilter mf;

    public Mesh meshBase;
    public Material materialBase;

    [Range(1f, 18f)]
    public float height;

    [Range(.1f, 4f)]
    public float width;
    public List<Vector3> trunkVerts;
    public List<int> trunkTris;

    public List<Color> trunkColors;

    [Range(1f, 18f)]
    public float size;
    
    public AnimationCurve sizeCurve;

    public AnimationCurve trunkCurve;

    public bool endCap;

    public void GenTrunk(float height, float width){
        trunkVerts.Clear();
        trunkTris.Clear();
        trunkColors.Clear();
        

        if(!mf)
            mf = GetComponent<MeshFilter>();
        //four vertices on transform position + width offset, follow rotation

        //add loop for every height increment
        for(int i = 0; i < height; i++){
            trunkVerts.Add(
                (Vector3.right * 
                (width/2f * trunkCurve.Evaluate((float)i/height)) + 
                (Vector3.up * i)
                ));
            //first
            trunkVerts.Add(
                (Vector3.forward * 
                (width/2f * trunkCurve.Evaluate((float)i/height)) + 
                (Vector3.up * i)
                ));
            //second
            trunkVerts.Add(
                (-Vector3.right * 
                (width/2f * trunkCurve.Evaluate((float)i/height)) + 
                (Vector3.up * i)
                ));
            //third
            trunkVerts.Add(
                (-Vector3.forward * 
                (width/2f * trunkCurve.Evaluate((float)i/height)) + 
                (Vector3.up * i)
                ));
            //fourth
            trunkColors.Add(Color.white * (float)i/height);
            trunkColors.Add(Color.white * (float)i/height);
            trunkColors.Add(Color.white * (float)i/height);
            trunkColors.Add(Color.white * (float)i/height);
        }

        for(int y = 0; y < height-1; y++){
            for(int x = 0; x < 4; x++){
                trunkTris.Add(x + (y*4));
                trunkTris.Add(x + 4 + (y*4));
                trunkTris.Add(((x + 1)%4) + 4 + (y*4));

                trunkTris.Add(x + (y*4));
                trunkTris.Add(((x + 1)%4) + 4 + (y*4));
                trunkTris.Add((x + 1)%4 + (y*4));

                
            }
        }

         Mesh mesh = new Mesh();
         mesh.name = "PlantGen";
         mesh.SetVertices(trunkVerts);
         mesh.SetTriangles(trunkTris, 0);
         mesh.SetColors(trunkColors);
         mesh.RecalculateNormals();

        mf.sharedMesh = mesh;

    }

    void GenBushel(Vector3 pos, float scale){
        GameObject bushel = new GameObject("Bushel: " + pos.ToString());
        bushel.AddComponent<MeshRenderer>().material = materialBase;
        bushel.AddComponent<MeshFilter>().sharedMesh = meshBase;
        
        bushel.transform.SetParent(transform);
        bushel.transform.position = pos;
        bushel.transform.localEulerAngles = Vector3.zero;
        bushel.transform.localScale = Vector3.one * scale * size;
    }

    public void Randomize(){
        size = Random.Range(1f, 18f);
        width = Random.Range(.1f, 4f);
        height = Random.Range(1f, 18f);
        Generate();
    }

    [ContextMenu("Gen Leaves")]
    public void Generate(){

        GenTrunk(height, width);

        for (int i = this.transform.childCount; i > 0; --i)
            DestroyImmediate(this.transform.GetChild(0).gameObject);

        for(int i = 0; i < height; i++){
            GenBushel(transform.position + (transform.TransformDirection(Vector3.up) * i * transform.localScale.y), sizeCurve.Evaluate((float)i/height));
        }
    }

    private void OnDrawGizmosSelected() {

        

    }
}

[CustomEditor(typeof(ProceduralPlantMesh))]
public class PlantEditor : Editor
{
    // Custom in-scene UI for when ExampleScript
    // component is selected.
    public void OnSceneGUI()
    {
        ProceduralPlantMesh handleExample = (ProceduralPlantMesh)target;

        if (handleExample == null)
        {
            return;
        }

        Handles.BeginGUI();
        if(GUILayout.Button("Reset Area", GUILayout.Width(100)))
        {
            handleExample.width =  12f;
        }
        Handles.EndGUI();
        
        handleExample.width = Handles.ScaleSlider(handleExample.width, handleExample.transform.position, handleExample.transform.position + handleExample.transform.forward * handleExample.width, handleExample.transform.rotation, 1f, 0f);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ProceduralPlantMesh procMesh = (ProceduralPlantMesh)target;
        if(GUILayout.Button("Update Parameters")){
            procMesh.Generate();
        }

        if(GUILayout.Button("Randomize Parameters")){
            procMesh.Randomize();
        }
    }
}