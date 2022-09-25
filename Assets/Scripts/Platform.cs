using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private float _delay = 5f;
    private Transform[] _points;
    private Transform target;
    private int _currentPoint;
    private float _time;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;
        target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (_time > _delay)
        {
            _time = 0f;
            
            if (transform.position == target.position)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }
        }
    }
}
