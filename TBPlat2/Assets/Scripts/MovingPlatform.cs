using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform[] movePoints;
    private int pointIndex = 0;
    private Transform currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = movePoints[pointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, moveSpeed);
        if(Vector2.Distance(transform.position, currentPoint.position)<0.001f)
        {
            pointIndex++;
            pointIndex %= movePoints.Length;
            currentPoint = movePoints[pointIndex];
        }
    }
}
