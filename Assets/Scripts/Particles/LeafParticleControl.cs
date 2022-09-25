using UnityEngine;

public class LeafParticleControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerEffectHandler>(out PlayerEffectHandler effect))
        {
            effect.LeafParticles();
        }
    }
    
}
