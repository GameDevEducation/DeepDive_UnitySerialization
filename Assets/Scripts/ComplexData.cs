using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexData : MonoBehaviour, ISerializationCallbackReceiver
{
    public Dictionary<string, int> GameStats;

    [SerializeField] List<string> GameStats_Keys;
    [SerializeField] List<int> GameStats_Values;

    [SerializeField] int PackedData;

    [System.NonSerialized] public int Health;
    [System.NonSerialized] public int JumpHeight;

    // this runs on LOAD after Unity has loaded the data that it can for our class
    public void OnAfterDeserialize()
    {
        // unpack the bitfield
        Health = PackedData & 0xFF;
        JumpHeight = (PackedData >> 8) & 0xFF;

        if (GameStats_Keys.Count != GameStats_Values.Count)
            throw new System.IndexOutOfRangeException("Mismatched size for keys and values");

        // construct the dictionary
        GameStats = new Dictionary<string, int>();
        for(int index = 0; index < GameStats_Keys.Count; ++index)
            GameStats[GameStats_Keys[index]] = GameStats_Values[index];
    }

    // this runs on SAVE before Unity writes the data it can for our class
    public void OnBeforeSerialize()
    {
        // pack the bitfield
        PackedData = (Health & 0xFF) | ((JumpHeight & 0xFF) << 8);

        if (GameStats != null)
        {
            GameStats_Keys = new List<string>(GameStats.Keys);
            GameStats_Values = new List<int>(GameStats.Values);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Health is " + Health);
        Debug.Log("Jump Height is " + JumpHeight);
        
        foreach(var kvp in GameStats)
        {
            Debug.Log(kvp.Key + " = " + kvp.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
