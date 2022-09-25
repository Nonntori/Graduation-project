using UnityEngine;

public class TransitionPlayerLoss : Transition
{
    [SerializeField] private float _distanceToTransit = 2f;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) > _distanceToTransit)
        {
            NeedTransition = true;
        }
    }
}

