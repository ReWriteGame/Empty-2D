using UnityEngine;

public class HeroVisual : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private ParticleSystem destroyPS;
    [SerializeField] private SkinController skinController;


    private void Start() => hero.OnDied.AddListener(Died);
    private void OnDestroy() => hero.OnDied.RemoveListener(Died);


    private void Died()
    {
        skinController.HideAllSkins();
        destroyPS.Play();
    }
}