using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    private Dictionary<string, string> _keys = new Dictionary<string, string>()
    {
        {"q", "é"},
        {"w", "ö"},
        {"e", "ó"},
        {"r", "ê"},
        {"t", "å"},
        {"y", "í"},
        {"u", "ã"},
        {"i", "ø"},
        {"o", "ù"},
        {"p", "ç"},
        {"[", "õ"},
        {"]", "ú"},
        {"a", "ô"},
        {"s", "û"},
        {"d", "â"},
        {"f", "à"},
        {"g", "ï"},
        {"h", "ð"},
        {"j", "î"},
        {"k", "ë"},
        {"l", "ä"},
        {";", "æ"},
        {"'", "ý"},
        {"z", "ÿ"},
        {"x", "÷"},
        {"c", "ñ"},
        {"v", "ì"},
        {"b", "è"},
        {"n", "ò"},
        {"m", "ü"},
        {",", "á"},
        {".", "þ"},
        {"`", "¸"},
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
