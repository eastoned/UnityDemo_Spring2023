using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private TextMeshProUGUI _text;

    public Agent currentAgent;

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
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f, ~LayerMask.NameToLayer("Agent"))){
                Debug.Log("Hitting:" + hit.transform.name);
                currentAgent = hit.transform.gameObject.GetComponent<Agent>();
                switch(GameManager.Instance.GameState){
                    case GameManager.State.Delete:
                        //hit.transform.gameObject.GetComponent<Agent>().Die();
                        currentAgent.Die();
                        Debug.Log("Destroy this: " + hit.transform.name);
                    break;
                    case GameManager.State.Duplicate:
                        ///hit.transform.gameObject.GetComponent<Agent>().Spawn();
                        currentAgent.Spawn();
                        Debug.Log("Create new: " + hit.transform.name);
                    break;
                    case GameManager.State.Push:
                        currentAgent.Push(Random.onUnitSphere, Random.Range(2f, 10f));
                        //hit.transform.gameObject.GetComponent<Agent>().Push(Random.onUnitSphere, Random.Range(2f, 10f));
                        Debug.Log("Push: " + hit.transform.name);
                    break;
                    default:
                    break;
                }
                currentAgent = null;
            }else if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f, ~LayerMask.NameToLayer("Default"))){
                if(GameManager.Instance.GameState == GameManager.State.Spawn){
                    
                }
            }
        }
    }

    void UpdateTextMode(GameManager.State gameState){
        _text.text = "Current mode: " + gameState.ToString();
    }
}
