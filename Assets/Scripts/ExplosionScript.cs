using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    public GameObject spawnerSample;

    private float _timeFromLastSpawn =2f;

    private void Update()
    {
        _timeFromLastSpawn += Time.deltaTime;
        if (_timeFromLastSpawn > 2f && !GetComponent<BoxCollider2D>().isActiveAndEnabled)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Particle" && _timeFromLastSpawn > 2f)
        {
            _timeFromLastSpawn = 0;
            Invoke("SpawnExplosion", 0.5f);
        }
        if(collision.tag == "Particle")
        {
            Destroy(collision.gameObject);
        }
    }

    public void SpawnExplosion()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        
        GameObject spawner = Instantiate(spawnerSample);
        spawner.transform.position = transform.position;
    }
}
