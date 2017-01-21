using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BouncerScript : MonoBehaviour {

    public Vector2 newDirection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Particle")
        {
            collision.GetComponent<SegmentScript>().ChangeDirection(newDirection);
        }
        
    }
}
