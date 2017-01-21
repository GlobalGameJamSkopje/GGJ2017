using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public float speedOfTravel;

    private Vector3 _direction;

    void Update()
    {
        transform.Translate(_direction * Time.deltaTime * speedOfTravel);
    }

    public void SetDirection(float x, float y)
    {
        _direction = new Vector3(x, y);
    }
}