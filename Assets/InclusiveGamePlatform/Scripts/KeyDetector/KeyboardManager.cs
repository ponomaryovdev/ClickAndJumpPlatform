using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Observer;

public class KeyboardManager : MonoBehaviour
{
    private string _lastKeyPressd;
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

    void Update()
    {
        if (Input.anyKeyDown)
        {
            DetectNewKey(Input.inputString);
        }
    }

    public void DetectNewKey(string newKey)
    {
        EventHolder<KeyDetectionInfo>.Notify(new KeyDetectionInfo(_keys.GetValueOrDefault(newKey.ToLower())));
    }
}
