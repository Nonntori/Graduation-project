using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StateStalking : State
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _distanceToStalking = 6f;

    private Rigidbody2D _rigidbody2d;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movePosition = new Vector2(Target.transform.position.x, _rigidbody2d.transform.position.y);

        if (Vector2.Distance(transform.position, Target.transform.position) < _distanceToStalking)
        {
            _rigidbody2d.position = Vector2.MoveTowards(transform.position, movePosition, _speed * Time.deltaTime);
        }
    }
}


