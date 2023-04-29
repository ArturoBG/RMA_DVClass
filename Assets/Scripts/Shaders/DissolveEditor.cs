using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DissolveScript))]
public class DissolveEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DissolveScript dissolveScript = (DissolveScript)target;

        if (GUILayout.Button("Dissolve In"))
        {
            dissolveScript.DissolveIn();
        }

        if (GUILayout.Button("Dissolve Out"))
        {
            dissolveScript.DissolveOut();
        }
    }
}
