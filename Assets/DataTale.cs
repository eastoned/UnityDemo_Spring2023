using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Write a C# script using variables (strings, floats, integers) for input. Tell a story through the inputs and how they change when the program is run.
Experiment with naming variables, conditional logic, and printing additional text to the console.

When posting this assignment to itch.io, please include the .CS file in your uploads.
*/

public class DataTale : MonoBehaviour
{
    
    public string words;
    public int number;
    public Pedestrian _person;
    public Spy _spyPerson;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Pedestrian{
    public string name = "John";
    public int age = 20;

}

[System.Serializable]
public class Spy : Pedestrian{
    public int suspicion = 1;
}