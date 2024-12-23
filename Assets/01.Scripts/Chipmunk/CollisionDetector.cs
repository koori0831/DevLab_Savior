using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    public UnityEvent collisionEnterEvent;
    public UnityEvent collisionExitEvent;
    void OnCollisionEnter2D(Collision2D other)
    {
        collisionEnterEvent?.Invoke();
    }
    void OnCollisionExit2D(Collision2D other)
    {
        collisionExitEvent?.Invoke();
    }
}
