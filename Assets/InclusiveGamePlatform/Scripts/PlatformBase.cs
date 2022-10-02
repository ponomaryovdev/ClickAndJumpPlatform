using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InclusiveGamePlatform.Core.Patterns.Observer;
using System.Linq;

public class PlatformBase : MonoBehaviour
{
    [Header("Left, Center, Right")]
    public List<Sprite> SpriteList = new List<Sprite>();
    private GameObject _keyPrefab;
    private GameObject _platformPart;
    private List<KeyDisplayBase> _keys = new List<KeyDisplayBase>();

    private void Awake()
    {
        var res = Resources.LoadAsync("KeyDisplay/IM_KeyDisplay");
        _keyPrefab = (GameObject)res.asset;
        var part = Resources.LoadAsync("UI/PlatformPart");
        _platformPart = (GameObject)part.asset;
    }

    private void OnEnable()
    {
        EventHolder<KeyDetectionInfo>.Subscribe(DetectNewKeyPressed);
    }

    private void DetectNewKeyPressed(KeyDetectionInfo newKeyInfo)
    {
        KeyDisplayBase tmp = _keys.First();
        if (tmp.Key == newKeyInfo.Key)
        {
            tmp.Despawn();
            _keys.Remove(tmp);
        }
    }

    public virtual void Init(KeyBlock keyBlock)
    {
        int count = keyBlock.keys.Count;
        int index = 0;
        LeanTween.value(0, 1, 0.15f).setOnUpdate((float val) => { }).setOnComplete(delegate() {SpawnKey(keyBlock.keys[index++]); } ).setRepeat(count);
        SpawnPlatform(count);

    }

    public void SpawnPlatform(int keyCount)
    {
        for (int i = 0; i <= keyCount-1; i++)
        {
            if(keyCount == 1 && i == 0)
            {
                Instantiate(_platformPart, transform.GetChild(0).GetChild(0));
            }

            if (keyCount > 1 && i == 0)
            {
                var PlatformPart = Instantiate(_platformPart, transform.GetChild(0).GetChild(0)).GetComponent<Image>();
                PlatformPart.sprite = SpriteList[0];
            }

            if (keyCount > 1 && i > 1)
            {
                var PlatformPart  = Instantiate(_platformPart, transform.GetChild(0).GetChild(0)).GetComponent<Image>();
                PlatformPart.sprite = SpriteList[1];
            }

            if (keyCount > 1 && i == keyCount-1)
            {
                var PlatformPart = Instantiate(_platformPart, transform.GetChild(0).GetChild(0)).GetComponent<Image>();
                PlatformPart.sprite = SpriteList[2];
            }
        }
    }

    public void SpawnKey(string key)
    {
        KeyDisplayBase keyTmp = Instantiate(_keyPrefab, transform.GetChild(0).GetChild(1)).GetComponent<KeyDisplayBase>();
        keyTmp.Init(key);
        _keys.Add(keyTmp);
    }

    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }
}
