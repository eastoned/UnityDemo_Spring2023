using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderVariable : MonoBehaviour
{
    [SerializeField] private Transform sphere;
    
    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_SpherePos", sphere.position);
    }
}
