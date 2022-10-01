using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformBase : MonoBehaviour
{
    [Header("Left, Center, Right")]
    public List<Sprite> SpriteList = new List<Sprite>();
    private GameObject _keyPrefab;
    private GameObject _platformPart;

    private void Awake()
    {
        var res = Resources.LoadAsync("KeyDisplay/IM_KeyDisplay");
        _keyPrefab = (GameObject)res.asset;
        var part = Resources.LoadAsync("UI/PlatformPart");
        _platformPart = (GameObject)part.asset;
    }

    public virtual void Init(KeyBlock keyBlock)
    {
        int count = keyBlock.keys.Count;
        int index = 0;
        LeanTween.value(0, 1, 0.15f).setOnUpdate((float val) => { }).setOnComplete(delegate() {SpawnKey(keyBlock.keys[index++]); } ).setRepeat(count);


    }

    public void SpawnPlatform(int keyCount)
    {
        for (int i = 0; i < keyCount; i++)
        {

        }
    }

    public void SpawnKey(string key)
    {
        KeyDisplayBase keyTmp = Instantiate(_keyPrefab, transform.GetChild(1).GetChild(0)).GetComponent<KeyDisplayBase>();
        keyTmp.Show();
    }

    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }
}
