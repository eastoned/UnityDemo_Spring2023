using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameState : MonoBehaviour
{
    public void ChangeGameManagerState(int gameState){
        GameManager.Instance.UpdateGameState((GameManager.State)gameState);
    }

    public void SpawnObject(string name){
        GameManager.Instance.CreateObject(name);
    }

    public void ClearAgents(){
        GameManager.Instance.Clear();
    }
}
