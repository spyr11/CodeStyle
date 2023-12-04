using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentIndex;

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
        var targetPoint = _points[_currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == targetPoint.position)
        {
            RiseIndex();
        }
    }

    private void RiseIndex()
    {
        _currentIndex++;

        if (_currentIndex >= _points.Length)
        {
            _currentIndex = 0;
        }
    }
}
