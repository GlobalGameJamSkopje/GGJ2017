using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public float speedOfTravel;

    private Vector3 _direction;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(_direction * speedOfTravel, ForceMode2D.Impulse);
    }

    public void SetDirection(float x, float y)
    {
        _direction = new Vector3(x, y);
    }

    void OnDestroy()
    {
        Destroy(gameObject.GetComponent<LineRenderer>());
    }
}