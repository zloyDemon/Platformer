using System;
using UniRx;
using UnityEngine;

public class MoveHorizontalComponent : BaseCharacterComponent
{
    private Vector2 _currentMoveDirection;

    public float MoveSpeed { get; }
    public Vector2 MoveDirection => _currentMoveDirection;

    public MoveHorizontalComponent(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
    }

    public override void FixedUpdateComponent(ICharacterEntity characterEntity)
    {
        var direction = characterEntity.Input.MoveDirection.normalized;
        _currentMoveDirection = direction;
        float xMove = _currentMoveDirection.x * MoveSpeed;
        characterEntity.Rigidbody2D.velocity = new Vector2(xMove, characterEntity.Rigidbody2D.velocity.y);
    }
}
