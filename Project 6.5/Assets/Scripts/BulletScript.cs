using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed = 6f;
    private Camera mainCam;

    // Use this for initialization
    void Start () {
        mainCam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(0f, speed * Time.deltaTime));
        if (transform.position.x >= mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x || transform.position.x <= mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x
            || transform.position.y >= mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y || transform.position.y <= mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathObj")
        {
            Destroy(collision.transform.parent.gameObject);
            Destroy(gameObject);
        }    
    }
}
