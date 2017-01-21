using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{

    public GameObject spawnerSample;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "SpawnArea")
            {
                GameObject spawner = Instantiate(spawnerSample);
                spawner.transform.position = position;
            }

        }
    }
}
