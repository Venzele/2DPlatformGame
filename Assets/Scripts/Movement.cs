using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;

    private CheckGround _checkGround;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _checkGround = FindObjectOfType<CheckGround>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _checkGround.IsGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _animator.Play("Jump");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            if (_checkGround.IsGround)
                _animator.Play("Walk");
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _spriteRenderer.flipX = true;
            if (_checkGround.IsGround)
                _animator.Play("Walk");
        }
        else if (_checkGround.IsGround)
        {
            _animator.Play("Idle");
        }
    }
}
