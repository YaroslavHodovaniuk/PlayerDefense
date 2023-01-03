using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.Self);
    }

    private void FixedUpdate()
    {
        DestroyBehindCamera();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
       {
            enemy.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }

    private void DestroyBehindCamera()
    {
        Vector3 point = _camera.WorldToViewportPoint(gameObject.transform.position);
        if (point.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
