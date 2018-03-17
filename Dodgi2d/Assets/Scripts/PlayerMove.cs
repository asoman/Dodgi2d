using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 10.0f;

    Vector3 direction = new Vector3();
    GameObject sprite;
	
    
    void Start()
    {
        sprite = transform.Find("Sprite").gameObject;
    }

	// Update is called once per frame
	void Update () {
        if (direction.magnitude > 0.1)
        {
            direction = Vector3.ClampMagnitude(direction, 3);
            Debug.Log(direction.magnitude);
            transform.Translate(direction * speed * Time.deltaTime);
        }
	}

    public void SetDirection(Vector3 direction)
    {
        Debug.Log(direction);
        this.direction = direction;
    }

    public void SetRotation(Vector3 point)
    {
        float AngleRad = Mathf.Atan2(point.x - transform.position.x, point.y - transform.position.y);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        sprite.transform.rotation = Quaternion.Euler(0, 0, -AngleDeg);
    }
}
