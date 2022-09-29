using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MPUIKIT;

[RequireComponent(typeof(AudioSource))]
public class KeyDisplayBase : MonoBehaviour
{
    public float TimeToShowHide = 0.5f;
    [Header("Show/Hide")]
    public List<AudioClip> Clips = new List<AudioClip>();
    
    private TextMeshProUGUI _keyDisplayText = null;
    private MPImage _mpImage = null;
    private AudioSource _audioSource = null;

    private void Awake()
    {
        _keyDisplayText = GetComponent<TextMeshProUGUI>();
        _mpImage = GetComponent<MPImage>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    public void Init(string key)
    {
        _keyDisplayText.text = key;
        Show();
    }

    public virtual void Show()
    {
        _audioSource.PlayOneShot(Clips[0]);
        var color = _mpImage.color;
        LeanTween.value(_mpImage.gameObject, 0, 1, TimeToShowHide).setOnUpdate((float val) => 
        {
            color = new Color(255, 255, 255, val);
            _mpImage.color = color; 
        });
        LeanTween.scale(gameObject, Vector3.one, TimeToShowHide).setEaseOutBack();
    }

    public virtual void Hide()
    {
        _audioSource.PlayOneShot(Clips[1]);
        var color = _mpImage.color;
        LeanTween.value(_mpImage.gameObject, 1, 0, TimeToShowHide).setOnUpdate((float val) =>
        {
            color = new Color(255, 255, 255, val);
            _mpImage.color = color;
        });
        LeanTween.scale(gameObject, Vector3.zero, TimeToShowHide).setEaseInBack();
    }
}