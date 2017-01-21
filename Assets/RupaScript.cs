using UnityEngine;

public class RupaScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="lopta")
        {
            collision.GetComponent<Animator>().SetTrigger("Win");
        }
        else if (collision.tag== "Particle")
        {
            Destroy(collision.gameObject);
        }
    }
}
