using UnityEngine;

public class KillingPlayerOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.ApplyeDamage(player.Health);
        }
    }
}
