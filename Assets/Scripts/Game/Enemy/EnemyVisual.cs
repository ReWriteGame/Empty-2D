using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private ParticleSystem destroyPS;
    [SerializeField] private SpriteRenderer skin;
    [SerializeField] private SpriteRenderer skinCanSelect;


    private void Start()
    {
        enemy.OnCollected.AddListener(Destroy);
        enemy.OnSetCanCollected.AddListener(RenderHarmless);
        skinCanSelect.enabled = false;
    }

    private void OnDestroy()
    {
        enemy.OnCollected.RemoveListener(Destroy);
        enemy.OnSetCanCollected.RemoveListener(RenderHarmless);
    }

    private void Destroy()
    {
        destroyPS.Play();
        skin.enabled = (false);
        skinCanSelect.enabled =(false);
    }
    
    private void RenderHarmless()
    {
        skinCanSelect.enabled = true;
        skin.enabled = false;
        
    }
}