using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GroundChecker _checkGround;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;

    private const string Idle = "Idle";
    private const string Walk = "Walk";
    private const string Jump = "Jump";

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _checkGround.IsGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _animator.Play(Jump);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            if (_checkGround.IsGround)
                _animator.Play(Walk);
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _spriteRenderer.flipX = true;
            if (_checkGround.IsGround)
                _animator.Play(Walk);
        }
        else if (_checkGround.IsGround)
        {
            _animator.Play(Idle);
        }
    }
}
