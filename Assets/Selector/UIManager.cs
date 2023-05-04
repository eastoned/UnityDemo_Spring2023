using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public List<Transform> playerColliders;
    public List<RectTransform> playerTextObjs;

    public ListAmountController listController;

    public ObjectController objectController;

    private Camera cam;

    public Vector2 nameOffset;

    void Start(){
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < playerColliders.Count; i++){
            playerTextObjs[i].position = cam.WorldToScreenPoint(playerColliders[i].position) + new Vector3(nameOffset.x, nameOffset.y, 0);    
        }

        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    [ContextMenu("Get Player Names")]
    public void UpdatePlayerData(){
        
        
        int playerCount = listController.playerCount;
        string[] playerNames = new string[playerCount];

        GameObject[] playerTextInputs = new GameObject[playerCount];
        playerTextInputs = listController.GetPlayerObjects();

        for(int i = 0; i < playerCount; i++){
            playerNames[i] = playerTextInputs[i].GetComponent<TMP_InputField>().text;
        }

        //update amount of text objects in scene and update their text component to read the same as the text field
        
        playerTextObjs = objectController.UpdatePlayerTexts(playerNames);
        playerColliders = objectController.UpdatePlayerColliders(playerNames);
    
        for(int i = 0; i < playerCount; i++){
            playerTextObjs[i].GetComponent<TextMeshProUGUI>().text = playerNames[i];
            playerTextObjs[i].transform.name = "Nametag: " + playerNames[i];
            playerColliders[i].transform.name = "Collider: " + playerNames[i];
        }

    }

    public void StartRace(){
        for(int i = 0; i < playerColliders.Count; i++){
            Rigidbody rb = playerColliders[i].GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
           // rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
