using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public State GameState;

    public List<GameObject> activeAgents = new List<GameObject>();

    public static event Action OnAgentDestroyed;
    public static event Action OnAgentCreated;

    public static event Action<State> OnGameStateChanged;

    public static GameManager Instance{
        get{
            if(!_instance){
                Debug.Log("Game manager is null. Creating instance");
                _instance = new GameObject().AddComponent<GameManager>();
                _instance.name = _instance.GetType().ToString();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    
    public enum State{
        Duplicate,
        Delete,
        Push
    }

    public void UpdateGameState(State gameState){
        GameState = gameState;
        switch (gameState){
            case State.Duplicate:
            break;
            case State.Delete:
            break;
            case State.Push:
            break;
            default:
            break;
        }
        OnGameStateChanged?.Invoke(gameState);
    }

    private void Awake(){
        _instance = this;
    }

    [ContextMenu("Test Event")]
    public void DestroyAgent(GameObject agent){
        activeAgents.Remove(agent);
        Destroy(agent);
        OnAgentDestroyed?.Invoke();
    }

    public void CreateObject(string obj){
        GameObject newObj = Instantiate(Resources.Load(obj, typeof(GameObject))) as GameObject;
        activeAgents.Add(newObj);
        OnAgentCreated?.Invoke();
    }

    public void Clear(){
        foreach(GameObject obj in activeAgents){
            //activeAgents.Remove(obj);
            Destroy(obj);
        }
        activeAgents.Clear();
    }


}
