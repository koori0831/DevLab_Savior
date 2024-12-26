using UnityEngine;

public class SlowArea : MonoBehaviour
{
    public void Initailize(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        other.attachedRigidbody.linearDamping = 2f;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.attachedRigidbody.linearDamping = 0f;
    }
}
