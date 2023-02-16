using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private float _patrolAreaSizeX = 10;
    [SerializeField] private float _patrolAreaSizeY = 2;
    [SerializeField] private float _minTimeBetweenChangeDestination = 1;
    [SerializeField] private float _maxTimeBetweenChangeDestination = 5;

    private Rect _area;

    private void Start()
    {
        CreateArea();
        StartCoroutine(Patroling());
    }

    private IEnumerator Patroling()
    {
        while (true)
        {
            print("patrol");
            // Vector3 newDestination = GetRandomPointInArea();
            // Agent.SetDestination(new Vector3(newDestination.x, transform.position.y, newDestination.y));
            yield return new WaitForSeconds(Random.Range(_minTimeBetweenChangeDestination, _maxTimeBetweenChangeDestination));
        }
    }

    private void CreateArea()
    {
        return;

        Vector2 areaCenter = new Vector2(transform.position.x - _patrolAreaSizeX / 2, transform.position.y - _patrolAreaSizeY / 2);
        Vector2 areaRadius = new Vector2(_patrolAreaSizeX, _patrolAreaSizeY);
        _area = new Rect(areaCenter, areaRadius);
    }

    private Vector2 GetRandomPointInArea()
    {
        return new Vector2(Random.Range(_area.xMin, _area.xMax), Random.Range(_area.yMin, _area.yMax));
    }
}
