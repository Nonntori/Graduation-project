using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private float _delaydLifting = 5f;

    private Transform[] _points;
    private Transform _target;
    private int _currentPoint;
    private float _time;
    private Coroutine _move;

    private void Start()
    {
        _points = new Transform[_path.childCount];
    
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
        
        StartCoroutine(Move());
    }
    
    private IEnumerator Move()
    {
        _time += Time.deltaTime;
        _target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (_time > _delaydLifting)
        {
            _time = 0f;
            
            if (transform.position == _target.position)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }
        }

        yield return null;
        StartCoroutine(Move());
    }
}
