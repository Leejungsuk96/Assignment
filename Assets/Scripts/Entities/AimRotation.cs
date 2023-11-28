using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer LookingPoint;
    [SerializeField] private Transform LookingPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector3 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        LookingPoint.flipY = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = LookingPoint.flipY;
        LookingPivot.rotation = Quaternion.Euler(0, 0, rotZ);

    }
}
