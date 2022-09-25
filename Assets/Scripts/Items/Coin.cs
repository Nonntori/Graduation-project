using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speedAttraction = 2f;
    [SerializeField] private float _distanceAttraction = 2f;
    [SerializeField] private GameObject _target;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Player player))
        {
            player.TakeCoin();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 movePosition = new Vector2(_target.transform.position.x, transform.position.y);

        if (Vector2.Distance(this.transform.position, _target.transform.position) < _distanceAttraction)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePosition, _speedAttraction * Time.deltaTime);
        }
    }
}