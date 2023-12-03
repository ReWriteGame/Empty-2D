using UnityEngine;


[CreateAssetMenu(fileName = "LoadURL", menuName = "ScriptableObjects/LoadURL", order = 10)]
public class LoadURL : ScriptableObject
{
    [SerializeField] private string linkText = "https://unity.com/ru";

    public void OpenURL() => Application.OpenURL(linkText);
}