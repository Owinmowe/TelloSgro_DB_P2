using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shape))]
public class EnemyController : MonoBehaviour
{

    [SerializeField] int pointsOnDeath = 10;
    public Action<int> OnPointsGiven;

    Shape currentShape;


    private void Awake()
    {
        currentShape = GetComponent<Shape>();
        currentShape.OnDestroy += OnDeath;
    }

    void OnDeath()
    {
        OnPointsGiven?.Invoke(pointsOnDeath);
    }
}
