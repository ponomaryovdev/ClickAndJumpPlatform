using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class D_RunAnyFunction : MonoBehaviour
{
    public bool RunOnStart = false;
    public UnityEvent Functions = new UnityEvent();

    private void Start()
    {
        if (RunOnStart)
        { 
            Functions.Invoke();
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(D_RunAnyFunction))]
public class D_RunAnyFunctionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (D_RunAnyFunction)target;

        if (GUILayout.Button("Run functions"))
        {
            script.Functions.Invoke();
        }
    }
}
#endif