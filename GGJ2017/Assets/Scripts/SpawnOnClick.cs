using UnityEngine;

public class SpawnOnClick : MonoBehaviour {

    public GameObject spawnerSample;

    void Update () {		
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {            
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject spawner = Instantiate(spawnerSample);
            spawner.transform.position = position;
        }
	}
}
