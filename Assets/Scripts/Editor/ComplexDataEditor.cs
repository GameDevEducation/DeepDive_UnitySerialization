using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ComplexData))]
public class ComplexDataEditor : Editor
{
    SerializedProperty GameStats_KeysProp;
    SerializedProperty GameStats_ValuesProp;

    public void OnEnable()
    {
        GameStats_KeysProp = serializedObject.FindProperty("GameStats_Keys");
        GameStats_ValuesProp = serializedObject.FindProperty("GameStats_Values");
    }

    public override void OnInspectorGUI()
    {
        ComplexData target = serializedObject.targetObject as ComplexData;

        // draw the keys and values as normal
        EditorGUILayout.PropertyField(GameStats_KeysProp);
        EditorGUILayout.PropertyField(GameStats_ValuesProp);

        // draw an integer field linked to health and height
        target.Health = EditorGUILayout.IntField("Health", target.Health);
        target.JumpHeight = EditorGUILayout.IntField("Jump Height", target.JumpHeight);

        // add a button to add data to the dictionary
        if (GUILayout.Button("Add data"))
        {
            Undo.RecordObject(target, "Set health");
            target.GameStats["Health"] = 100;
            target.GameStats["JumpHeight"] = 2;
        }

        // apply the modifications
        serializedObject.ApplyModifiedProperties();
    }
}
