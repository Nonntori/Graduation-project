using UnityEngine;

public class TrackingPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _xOffset, _player.transform.position.y - _yOffset, transform.position.z);
    }
}
