using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Observer;

public class KeyboardManager : MonoBehaviour
{
    private string _lastKeyPressd;
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
