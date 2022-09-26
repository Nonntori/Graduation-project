using UnityEngine;
using UnityEngine.Serialization;

public class FlipCharacter : MonoBehaviour
{
    [SerializeField] private GameObject _character;

    private bool _isFacingRight = true;
    private float _previousPositionX;

    private void Start()
    {
        _previousPositionX = transform.position.x;
    }

    private void Update()
    {
        if (_character.transform.position.x > _previousPositionX && !_isFacingRight)
        {
            Flip();
        }

        if (_character.transform.position.x < _previousPositionX && _isFacingRight)
        {
            Flip();
        }

        _previousPositionX = transform.position.x;
    }

    private void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        _isFacingRight = !_isFacingRight;
    }
}
