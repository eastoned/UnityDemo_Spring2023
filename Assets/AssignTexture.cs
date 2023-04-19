using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignTexture : MonoBehaviour
{
    public ComputeShader shader;
    public int texResolution = 256;

    public Texture texture;
    Renderer rend;
    RenderTexture inputTex, outputTex;
    int kernelHandle;
    // Start is called before the first frame update
    void Start()
    {
        outputTex = new RenderTexture(texResolution, texResolution, 24);
        outputTex.wrapMode = TextureWrapMode.Repeat;
        outputTex.filterMode = FilterMode.Point;
        outputTex.useMipMap = false;
        outputTex.enableRandomWrite = true;
        outputTex.Create();

        inputTex = new RenderTexture(texResolution, texResolution, 24);
        inputTex.wrapMode = TextureWrapMode.Repeat;
        inputTex.filterMode = FilterMode.Point;
        inputTex.useMipMap = false;
        inputTex.enableRandomWrite = true;
        inputTex.Create();
   
        Graphics.Blit(texture, inputTex);

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        InitShader();
    }

    private void InitShader(){
        kernelHandle = shader.FindKernel("CSMain");
        shader.SetTexture(kernelHandle, "Input", inputTex);
        shader.SetTexture(kernelHandle, "Result", outputTex);
        rend.material.SetTexture("_MainTex", outputTex);

        DispatchShader(texResolution/8, texResolution/8);

    }

    private void DispatchShader(int x, int y){
        shader.Dispatch(kernelHandle, x, y, 1);
    }

    private void Update(){
        shader.SetTexture(kernelHandle, "Result", outputTex);
        shader.SetTexture(kernelHandle, "Input", inputTex);
        DispatchShader(texResolution/8, texResolution/8);
        rend.material.SetTexture("_MainTex", outputTex);
        
    }

}
