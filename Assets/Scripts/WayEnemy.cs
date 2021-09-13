using UnityEngine;

public class WayEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;
    [SerializeField] private ContactFilter2D _filter;

    private int _distanceToObject = 1;
    private bool _isDirectionToRight = true;

    private RaycastHit2D[] _results = new RaycastHit2D[1];

    private void FixedUpdate()
    {
        var collisionOnRight = _rigidbody.Cast(transform.right, _filter, _results, _distanceToObject);
        var collisionOnLeft = _rigidbody.Cast(transform.right, _filter, _results, -_distanceToObject);

        if (collisionOnRight > 0)
        {
            _isDirectionToRight = false;
        }
        else if (collisionOnLeft > 0)
        {
            _isDirectionToRight = true;
        }

        if (_isDirectionToRight)
        {
            _rigidbody.velocity = transform.right * _speed;
            _spriteRenderer.flipX = false;
        }
        else if (!_isDirectionToRight)
        {
            _rigidbody.velocity = transform.right * -_speed;
            _spriteRenderer.flipX = true;
        }
    }
}
