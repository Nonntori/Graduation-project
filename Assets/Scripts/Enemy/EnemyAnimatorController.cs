using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Walk = nameof(Walk);
        public const string Dead = nameof(Dead);
        public const string Attack = nameof(Attack);
    }
}
