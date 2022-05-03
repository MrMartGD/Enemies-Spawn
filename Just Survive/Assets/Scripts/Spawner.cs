using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _allSpawnPoints;
    [SerializeField] private float _repeatTime = 2f;
    [SerializeField] private int _repeatCount = 10;
    
    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_allSpawnPoints.childCount];

        for (int i = 0; i < _allSpawnPoints.childCount; i++)
        {
            _points[i] = _allSpawnPoints.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_repeatTime);
        
        for(int i = 0; i < _repeatCount; i++) 
        {
            Instantiate(_enemy, _points[Random.Range(0, _points.Length)].position, Quaternion.Euler(0,90,0));
            yield return waitForSeconds;
        }
    }
}
