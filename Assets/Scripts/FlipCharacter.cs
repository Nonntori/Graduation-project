using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    [SerializeField] GameObject GameObject;

    private bool _isFacingRight = true;
    private float _previousPositionX;

    private void Start()
    {
        _previousPositionX = transform.position.x;
    }

    private void Update()
    {
        if (GameObject.transform.position.x > _previousPositionX && !_isFacingRight)
        {
            Flip();
        }

        if (GameObject.transform.position.x < _previousPositionX && _isFacingRight)
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
