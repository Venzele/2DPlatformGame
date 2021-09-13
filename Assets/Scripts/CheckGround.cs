using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
            IsGround = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
            IsGround = true;
    }
}
