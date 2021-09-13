using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement hero))
        {
            Destroy(gameObject);
        }
    }
}
