using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public static class States
    {
        public const string Jump = nameof(Jump);
        public const string Attack = nameof(Attack);
        public const string Ground = nameof(Ground);
        public const string Dead = nameof(Dead);
    }
    
    public static class Params
    {
        public const string Speed = nameof(Speed);
    }
}
