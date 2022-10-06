using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

[RequireComponent(typeof(AudioSource))]
public class UIButtonAnimated : UIButton
{
    public Vector3 OnHoverScale = Vector3.one;
    public float TimeToHoverScale = 0.2f;
    [Header("Click, Hover")]
    public List<AudioClip> Clips = new List<AudioClip>();

    private AudioSource _audioSource = null;

    protected override void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (Clips.Count > 0)
            _audioSource.PlayOneShot(Clips[0]);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        LeanTween.scale(gameObject, OnHoverScale, TimeToHoverScale);

        if(Clips.Count > 1)
            _audioSource.PlayOneShot(Clips[1]);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        LeanTween.scale(gameObject, Vector3.one, TimeToHoverScale);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        LeanTween.scale(gameObject, OnHoverScale, TimeToHoverScale);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        LeanTween.scale(gameObject, Vector3.one, TimeToHoverScale);
    }
}

[CustomEditor(typeof(UIButtonAnimated))]
public class UIButtonAnimatedEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}