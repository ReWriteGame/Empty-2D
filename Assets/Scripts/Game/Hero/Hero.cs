using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D collider;
    [SerializeField] private bool isDied = false;

    public UnityEvent OnDied;

    public bool IsDied => isDied;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
           Died();

    }

    private void Died()
    {
        if (isDied) return;
        rb.isKinematic = true;
        collider.enabled = false;
        isDied = true;
        OnDied?.Invoke();
    }
}