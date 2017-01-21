using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class SpawnerScript : MonoBehaviour
{
    public GameObject spawnerSample;

    private float _timeFromLastSpawn;

    private void Update()
    {
        _timeFromLastSpawn += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Particle" && _timeFromLastSpawn > 0.2f)
        {
            _timeFromLastSpawn = 0;
            GameObject spawner = Instantiate(spawnerSample);
            spawner.transform.position = collision.transform.position;
        }
        else if (collision.tag == "Particle")
        {
            Destroy(collision.gameObject);
        }

    }
}
