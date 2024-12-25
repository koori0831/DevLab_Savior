using UnityEngine;

[CreateAssetMenu(menuName = "MoveModerator")]
public class MoveModerator : EventModerator<MoveModerator>
{
    public Rigidbody2D rigidCompo { get; private set; }
    public Vector2 moveDirection { get; private set; }
    public float MoveSpeed { get; set; }
    [SerializeField] private bool addToVelocity;
    [SerializeField] private float moveSpeed;
    public void Initialize(Rigidbody2D rb, Vector2 moveDir, float additiveSpeed = 0)
    {
        this.rigidCompo = rb;
        this.MoveSpeed = moveSpeed + additiveSpeed;
        this.moveDirection = moveDir.normalized;
    }
    protected override void Excute()
    {
        Vector2 moveVector = addToVelocity ? rigidCompo.velocity + moveDirection * MoveSpeed : moveDirection * MoveSpeed;
        rigidCompo.linearVelocity = moveVector;
    }
}
