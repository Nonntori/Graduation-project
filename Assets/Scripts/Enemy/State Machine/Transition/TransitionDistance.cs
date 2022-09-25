using UnityEngine;

public class TransitionDistance : Transition
{
    [SerializeField] private float _distanceToTransit;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _distanceToTransit)
        {
            NeedTransition = true;
        }
    }
}
