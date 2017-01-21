using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public float speedOfTravel;

    private Vector3 _direction;

    public float timeAlive = 0;


    // commented line 
    public GameObject SpawnerSegment;
    // end

    void Update()
    {
        timeAlive += Time.deltaTime;
        transform.Translate(_direction * Time.deltaTime * speedOfTravel);
    }

    public void SetDirection(float x, float y)
    {
        _direction = new Vector3(x, y);
    }
    public void ChangeDirection(Vector2 newDirection)
    {
        _direction = new Vector3(_direction.x * newDirection.x, _direction.y * newDirection.y);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Destroyer")
    //    {
    //        if (_timeAlive > 0.2f)
    //        {
    //            GameObject spawnerSegment = Instantiate(SpawnerSegment);
    //            spawnerSegment.transform.position = gameObject.transform.position;
    //        }
    //        Destroy(gameObject);
    //    }
    //}
}