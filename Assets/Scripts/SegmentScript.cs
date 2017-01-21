using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public float speedOfTravel;

    private Vector3 _direction;

    private float _timeAlive = 0;
    

    // commented line 
    public GameObject SpawnerSegment;
    // end

    void Update()
    {
        _timeAlive += Time.deltaTime;
        transform.Translate(_direction * Time.deltaTime * speedOfTravel);
    }

    public void SetDirection(float x, float y)
    {
        _direction = new Vector3(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_timeAlive > 0.2f)
        {
            GameObject spawnerSegment = Instantiate(SpawnerSegment);
            spawnerSegment.transform.position = gameObject.transform.position;
        }     

        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}