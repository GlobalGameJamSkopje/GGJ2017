using UnityEngine;
using UnityEngine.UI;

public class SpawnOnClick : MonoBehaviour
{
    public GameObject spawnerSample;
    public GameObject loseCanvas;

    public Text text;

    private int _loseCounter = 3;
    private Rigidbody2D _loptaRigidBody2D;

    private void Start()
    {
        text.text = _loseCounter.ToString();
        _loptaRigidBody2D = GameObject.FindObjectOfType<LoptaScript>().GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (_loseCounter > 0 && Input.GetKeyDown(KeyCode.Mouse0) && FindObjectsOfType<ParticleSpawnerScript>().Length == 0)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "SpawnArea")
            {
                GameObject spawner = Instantiate(spawnerSample);
                spawner.transform.position = position;
                _loseCounter--;
                text.text = _loseCounter.ToString();
            }
        }

        if (_loseCounter == 0 && _loptaRigidBody2D != null && _loptaRigidBody2D.velocity == Vector2.zero && FindObjectsOfType<ParticleSpawnerScript>().Length == 0)
        {
            _loseCounter = -1;
            loseCanvas.SetActive(true);
        }
    }
}
