using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NameChangeDemo : MonoBehaviour
{
    [FormerlySerializedAs("Scres")]
    public List<int> Scores;

    [FormerlySerializedAs("Title")]
    public string LevelTitle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
