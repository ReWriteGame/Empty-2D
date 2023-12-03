using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        DestroyObject(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyObject(other.gameObject);
    }

    private void DestroyObject(GameObject obj) =>   Destroy(obj);
  
}
