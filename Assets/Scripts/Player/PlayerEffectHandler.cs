using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(Player))]
public class PlayerEffectHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dustFromRunning;
    [SerializeField] private ParticleSystem _dustFromJump;
    [SerializeField] private ParticleSystem _coinCollected;
    [SerializeField] private ParticleSystem _swirlOfLeaves;

    private PlayerMovement _playerMovement;
    private Player _player;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _player = GetComponent<Player>();
    }
    
    private void FixedUpdate()
    {
        Run();
    }

    private void OnEnable()
    {
        _playerMovement.DustFormJumped += OnDustFormJumped;
        _player.RaisedObject += OnRaisedObject;
    }

    private void OnDisable()
    {
        _playerMovement.DustFormJumped -= OnDustFormJumped;
        _player.RaisedObject -= OnRaisedObject;
    }
    
    public void LeafParticles()
    {
        if (!_swirlOfLeaves.isPlaying)
        {
            _swirlOfLeaves.Play();
        }
        else
        {
            _swirlOfLeaves.Stop();
        }
    }
    
    private void Run()
    {
        if (_playerMovement.Ground)
        {
            if (!_dustFromRunning.isPlaying && _playerMovement.VelocityX != 0)
            {
                _dustFromRunning.Play();
            }
        }
        else
        {
            _dustFromRunning.Stop();
        }
    }

    private void OnDustFormJumped()
    {
        if (_playerMovement.Ground)
        {
            _dustFromJump.Play();
        }
        else
        {
            _dustFromJump.Stop();
        }
    }

    private void OnRaisedObject()
    {
        Instantiate(_coinCollected, transform.position, Quaternion.identity);
    }
}
