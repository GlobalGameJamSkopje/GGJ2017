using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Particle")
        {
            Destroy(collision.gameObject);
        }
    }
}
