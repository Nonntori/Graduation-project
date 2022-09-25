using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Vector2 _parallaxEffectMultiplier;

    private Vector3 _lastCameraPosition;

    private void Start()
    {
        _lastCameraPosition = _cameraTransform.position;
    }

    private void FixedUpdate()
    {
        var deltaMovement = _cameraTransform.position - _lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * _parallaxEffectMultiplier.x, deltaMovement.y * _parallaxEffectMultiplier.y, 0);
        _lastCameraPosition = _cameraTransform.position;
    }
}
