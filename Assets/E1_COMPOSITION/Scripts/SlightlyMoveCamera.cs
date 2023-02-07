using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightlyMoveCamera : MonoBehaviour
{
    public float cameraMaxY, cameraMaxX, currentX, currentY;

    private Transform camPos;

    void Start(){
        camPos = GetComponent<Transform>();
        currentX = camPos.localEulerAngles.x;
        currentY = camPos.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.mousePosition.x/Screen.width;
        float x = Input.mousePosition.y/Screen.height;
        camPos.localEulerAngles = new Vector3(Mathf.Lerp(currentX + cameraMaxX, currentX - cameraMaxX, x), Mathf.Lerp(currentY - cameraMaxY, currentY + cameraMaxY, y), camPos.localEulerAngles.z);
    }
}
