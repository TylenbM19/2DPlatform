using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Controler))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(LayerMask))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _forseJump;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private bool _onGround;
    private float _checkRadius = 0.1f;
    private const string IsWalk = "Walk";
    private const string IsJump = "onGround";
    private Animator _animator;
    private Controler _controler;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _controler = GetComponent<Controler>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Flip();
    }
    private void FixedUpdate()
    {
        ChekingGround();
    }

    private void OnEnable()
    {
        if (_controler != null)
        {
            _controler.OnMove += Walk;
            _controler.OnJump += Jump;
        }
    }

    private void OnDisable()
    {
        if (_controler != null)
        {
            _controler.OnJump -= Jump;
            _controler.OnMove -= Walk;
        }
    }

    private void Walk(Vector2 direction)
    {
        _rigidbody.velocity = new Vector2(direction.x * _speedWalk, _rigidbody.velocity.y);
        _animator.SetFloat(IsWalk, direction.magnitude);
    }

    private void Flip()
    {
        if (_rigidbody.velocity.x != 0)
            _spriteRenderer.flipX = _rigidbody.velocity.x < 0f;
    }

    private void Jump()
    {
        if(_onGround)
         _rigidbody.velocity = Vector2.up * _forseJump;
    }

    private void ChekingGround()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _groundMask);
        _animator.SetBool(IsJump, _onGround);
    }
}
