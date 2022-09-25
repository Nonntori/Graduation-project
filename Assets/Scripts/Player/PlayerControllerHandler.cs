using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerControllerHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PauseMenu _menu;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += ctx => _playerMovement.Jump();
        _playerInput.Player.Attack.performed += ctx => _playerAttack.Attack();
        _playerInput.Player.Move.performed += ctx => _playerMovement.Move(ctx.ReadValue<float>());
        _playerInput.Player.Move.canceled += ctx => _playerMovement.StopMove();
        _playerInput.Player.Menu.performed += ctx => _menu.OpenPanel();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}