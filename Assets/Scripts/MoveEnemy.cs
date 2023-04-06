using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [HideInInspector] public float _speed = 2f;
    private float _leftEdge;

    private void Start()
    {
        _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * _speed * Time.fixedDeltaTime;

        if (transform.position.x < _leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
