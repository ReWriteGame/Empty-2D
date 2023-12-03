using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SkinController : MonoBehaviour
{
    [SerializeField] private List<GameObject> skins;

    private int currentIndex = 0;
    private int lastIndex = 0;

    private Action<int> OnUpdateIndex;
    private Action<GameObject> OnUpdateSkin;

    public List<GameObject> Skins => skins;
    public GameObject CurrentSkinGameObject => skins[CurrentIndex];
    public int CurrentIndex => currentIndex;
    public int LastIndex => lastIndex;

    public void SetSkin(int index)
    {
        if (index == currentIndex) return;
        index = Mathf.Clamp(index, 0, skins.Count);
        lastIndex = currentIndex;
        currentIndex = index;
        OnUpdateIndex?.Invoke(index);
    }

    public void UpdateSkin()
    {
        HideAllSkins();
        ShowCurrentSkin();
        OnUpdateSkin?.Invoke(CurrentSkinGameObject);
    }

    public void HideAllSkins() => skins.ForEach(x => x.SetActive(false));
    public void ShowCurrentSkin() => skins[currentIndex].SetActive(true);
    public void HideCurrentSkin() => skins[currentIndex].SetActive(false);

    public void SetRandomIndex() => SetSkin(Random.Range(0, skins.Count));
}