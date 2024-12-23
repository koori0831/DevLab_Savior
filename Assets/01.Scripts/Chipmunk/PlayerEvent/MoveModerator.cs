using UnityEngine;

[CreateAssetMenu(menuName = "MoveModerator")]
public class MoveModerator : EventModerator<MoveModerator>
{
    public Rigidbody2D rigidCompo { get; private set; }
    public Vector2 moveDirection { get; private set; }
    public float MoveSpeed { get; set; }
    [SerializeField] private float moveSpeed;
    public void Initialize(Rigidbody2D rb, Vector2 moveDir)
    {
        this.rigidCompo = rb;
        this.MoveSpeed = moveSpeed;
        this.moveDirection = moveDir.normalized;
    }
    protected override void Excute()
    {
        rigidCompo.linearVelocity = moveDirection * MoveSpeed;
    }
}
