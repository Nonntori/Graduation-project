using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ChangingHealth += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.ChangingHealth -= OnValueChanged;
    }
}
