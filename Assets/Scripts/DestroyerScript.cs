using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Particle")
        {
            Destroy(collision.gameObject);
        }
    }
}
