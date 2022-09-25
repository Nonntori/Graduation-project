public class TransitionPlayerDeath : Transition
{
    private void Update()
    {
        if (Target.Health <= 0)
        {
            NeedTransition = true;
        }
    }
}
