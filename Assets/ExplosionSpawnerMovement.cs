using UnityEngine;

public class ExplosionSpawnerMovement : MonoBehaviour {

	private enum Direction{up, down, left, right};
	private Direction direction;

	public float speed;
	public float upperY;
	public float lowerY;
	public bool flagUpDown;
	public float lefterX;
	public float righterX;

	// Use this for initialization
	void Start () {
		if(flagUpDown)
			direction = Direction.up;
		if(!flagUpDown)
			direction = Direction.right;
	}
	
	// Update is called once per frame
	void Update () {
		switch(direction){
			case Direction.up:
				transform.position += Vector3.up * speed * Time.deltaTime;
				break;
			case Direction.down:
				transform.position += Vector3.down * speed * Time.deltaTime;
				break;
			case Direction.left:
				transform.position += Vector3.left * speed * Time.deltaTime;
				break;
			case Direction.right:
				transform.position += Vector3.right * speed * Time.deltaTime;
				break;
		}

		if(flagUpDown){
			if(transform.position.y > upperY)
				direction = Direction.down;
			if(transform.position.y < lowerY)
				direction = Direction.up;
		}
		if(!flagUpDown){
			if(transform.position.x < lefterX)
				direction = Direction.right;
			if(transform.position.x > righterX)
				direction = Direction.left;
		}
		
	}
}
