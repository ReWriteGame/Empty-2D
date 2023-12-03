using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D collider;
    [SerializeField] private float delayDestroy = 2;
    
    public UnityEvent OnCollected;
    public UnityEvent OnSetCanCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Hero hero))
            Collected();
    }

    private void Collected()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        collider.enabled = false;
        OnCollected?.Invoke();
        Destroy(gameObject,delayDestroy);
    }
}
