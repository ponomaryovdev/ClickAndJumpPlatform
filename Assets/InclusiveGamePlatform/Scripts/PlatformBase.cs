using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBase : MonoBehaviour
{
    private GameObject _keyPrefab;

    private void Awake()
    {
        var res = Resources.LoadAsync("KeyDisplay/IM_KeyDisplay");
        _keyPrefab = (GameObject)res.asset;
    }

    public virtual void Init(KeyBlock keyBlock)
    {
        int count = keyBlock.keys.Count;
        int index = 0;
        LeanTween.value(0, 1, 0.25f).setOnUpdate((float val) => { }).setOnComplete(delegate() {SpawnKey(keyBlock.keys[index++]); } ).setRepeat(count);


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
