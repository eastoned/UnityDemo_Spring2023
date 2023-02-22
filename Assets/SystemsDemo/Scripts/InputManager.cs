using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private TextMeshProUGUI _text;

    void Start(){
        cam = GetComponent<Camera>();
    }
    private void OnEnable() {
        GameManager.OnGameStateChanged += UpdateTextMode;
    }
    private void OnDisable() {
        GameManager.OnGameStateChanged -= UpdateTextMode;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f)){
                switch(GameManager.Instance.GameState){
                    case GameManager.State.Delete:
                        Debug.Log("Destroy this: " + hit.transform.name);
                    break;
                    case GameManager.State.Duplicate:
                        Debug.Log("Create new: " + hit.transform.name);
                    break;
                    case GameManager.State.Push:
                        Debug.Log("Push: " + hit.transform.name);
                    break;
                    default:
                    break;
                }
            }
        }
    }

    void UpdateTextMode(GameManager.State gameState){
        _text.text = "Current mode: " + gameState.ToString();
    }
}
