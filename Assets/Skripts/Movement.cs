using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Controler))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _forseJump;
    [SerializeField] private Animator _animator;

    private const string IsWalk = "Walk";
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

    private void OnEnable()
    {
        if (_controler != null)
        {
            _controler.OnJump += Jump;
            _controler.OnMove += Walk;
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
        if(_rigidbody.velocity.x != 0)
        _spriteRenderer.flipX = _rigidbody.velocity.x < 0f;
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _forseJump;
    }
}
