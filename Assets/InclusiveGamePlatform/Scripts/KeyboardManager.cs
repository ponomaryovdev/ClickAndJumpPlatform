using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    private Dictionary<string, string> _keys = new Dictionary<string, string>()
    {
        {"q", "�"},
        {"w", "�"},
        {"e", "�"},
        {"r", "�"},
        {"t", "�"},
        {"y", "�"},
        {"u", "�"},
        {"i", "�"},
        {"o", "�"},
        {"p", "�"},
        {"[", "�"},
        {"]", "�"},
        {"a", "�"},
        {"s", "�"},
        {"d", "�"},
        {"f", "�"},
        {"g", "�"},
        {"h", "�"},
        {"j", "�"},
        {"k", "�"},
        {"l", "�"},
        {";", "�"},
        {"'", "�"},
        {"z", "�"},
        {"x", "�"},
        {"c", "�"},
        {"v", "�"},
        {"b", "�"},
        {"n", "�"},
        {"m", "�"},
        {",", "�"},
        {".", "�"},
        {"`", "�"},
    };

    private void Awake()
    {
    }


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            var keyPressed = Input.inputString;
            Debug.Log(keyPressed);
        }
    }
}
