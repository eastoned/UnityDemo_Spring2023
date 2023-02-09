using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiveMeMesh : MonoBehaviour
{
    [SerializeField] private Mesh[] meshes;
    MeshRenderer[] rends;
    [SerializeField] private MeshFilter mf;
    [SerializeField] private TMP_Dropdown selection;

    
    public void SetMeshShape(int val){
    }

}
