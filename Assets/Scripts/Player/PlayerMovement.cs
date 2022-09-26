using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _minGroundNormalY = 0.65f;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private LayerMask _layerMask;
    
    private const float minMoveDistance = 0.001f;
    private const float shellRadius = 0.01f;
    private Vector2 _targetVelocity;
    private bool _ground;
    private Vector2 _groundNormal;
    private Rigidbody2D _rigidbody;
    private ContactFilter2D _contactFilter;
    private RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> _hitBufferList = new List<RaycastHit2D>(16);
    
    public float VelocityX => _targetVelocity.x;
    public float Speed => _speed;
    public bool Ground => _ground;
    
    public event UnityAction Run;
    public event UnityAction StopMoving;
    public event UnityAction Jumped;
    public event UnityAction Grounded;
    public event UnityAction DustFormJumped; 
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(_layerMask);
        _contactFilter.useLayerMask = true;
    }
    
    private void FixedUpdate()
    {
        _velocity += Physics2D.gravity * (_gravityModifier * Time.deltaTime);
        _velocity.x = _targetVelocity.x;
    
        _ground = false;
    
        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);
        Vector2 move = moveAlongGround * (deltaPosition.x * _speed);
        
        Movement(move, false);
    
        move = Vector2.up * deltaPosition.y;
    
        Movement(move, true);

        if (_ground == true)
        {
            Grounded?.Invoke();
        }
    }
    
    public void Move(float velocityX)
    {
        _targetVelocity = new Vector2(velocityX, 0);
        Run?.Invoke();
    }

    public void StopMove()
    {
        _targetVelocity = new Vector2(0, 0);
        StopMoving?.Invoke();
    }
    
    public void Jump()
    {
        if (_ground)
        {
            Jumped?.Invoke();
            DustFormJumped?.Invoke();
            _velocity.y = _jumpForce;
            _groundNormal = Vector2.up;
        }
    }
    
    private void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;
    
        if (distance > minMoveDistance)
        {
            int count = _rigidbody.Cast(move, _contactFilter, _hitBuffer, distance + shellRadius);
            _hitBufferList.Clear();
    
            for (int i = 0; i < count; i++)
            {
                _hitBufferList.Add(_hitBuffer[i]);
            }
    
            for (int i = 0; i < _hitBufferList.Count; i++)
            {
                Vector2 currentNormal = _hitBufferList[i].normal;
    
                if (currentNormal.y > _minGroundNormalY)
                {
                    _ground = true;
    
                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
    
                float projection = Vector2.Dot(_velocity, currentNormal);
    
                if (projection < 0)
                {
                    _velocity -= projection * currentNormal;
                }
    
                float modifiedDistance = _hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }
    
        _rigidbody.position += move.normalized * distance;
    }
}
