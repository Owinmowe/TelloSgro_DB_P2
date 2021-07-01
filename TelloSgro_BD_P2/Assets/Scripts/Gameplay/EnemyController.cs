using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shape))]
public class EnemyController : MonoBehaviour
{

    [SerializeField] int pointsOnDeath = 10;
    public Action<int> OnPointsGiven;

    Shape currentShape;
    Transform target;

    bool following = true;

    private void Awake()
    {
        currentShape = GetComponent<Shape>();
        currentShape.OnDestroy += OnDeath;
    }

    private void Update()
    {
        if(!following) { return; }
        currentShape.Move(target.position);
    }

    public void StopFollowing()
    {
        following = false;
        target = null;
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void OnDeath()
    {
        OnPointsGiven?.Invoke(pointsOnDeath);
    }
}
