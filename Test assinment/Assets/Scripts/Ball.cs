using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball: MonoBehaviour
{
    public const string DeathZoneTag = "DeathZone";
    public const string FinishTag = "Finish";

    public event Action OutOfTheTrack;
    public event Action FinishTrack;

    [SerializeField] Vector3 _startPos = new Vector3(0, 0.5f, 0);
    [SerializeField] private float _aceleration = 10;
    [SerializeField] private float _maxSpeed = 10;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(DeathZoneTag))
        {
            OutOfTheTrack?.Invoke();
        }
        else if (other.CompareTag(FinishTag))
        {
            FinishTrack?.Invoke();
        }
    }

    public void Move(MoveDirection moveDirection)
    {
        Vector3 direction = moveDirection switch
        {
            MoveDirection.forward => Vector3.forward,
            MoveDirection.backward => Vector3.back,
            MoveDirection.right => Vector3.right,
            MoveDirection.left => Vector3.left,
            _ => Vector3.zero,
        };
        Move(direction);
    }

    public void Move(Vector3 direction)
    {
        float bouncedX = Math.Abs(_rigidbody.velocity.x) > _maxSpeed && _rigidbody.velocity.x * direction.x > 0 ? 0 : direction.x;
        float bouncedY = Math.Abs(_rigidbody.velocity.y) > _maxSpeed && _rigidbody.velocity.y * direction.y > 0 ? 0 : direction.y;
        float bouncedZ = Math.Abs(_rigidbody.velocity.z) > _maxSpeed && _rigidbody.velocity.z * direction.z > 0 ? 0 : direction.z;
        Vector3 bouncedDirection = new Vector3(bouncedX, bouncedY, bouncedZ);
        _rigidbody.AddForce(bouncedDirection * _aceleration * Time.deltaTime, ForceMode.VelocityChange);
    }

    public void SetupDefaults()
    {
        transform.position = _startPos;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    public enum MoveDirection
    {
        forward,
        backward,
        right,
        left
    }
}
