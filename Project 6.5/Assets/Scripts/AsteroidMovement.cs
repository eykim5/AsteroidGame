using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    public float horiSpeed = 0f;
    public float vertSpeed = 2.5f;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    void Update() {
        if (transform.position.x >= mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 2f || transform.position.x <= mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 2f
            || transform.position.y >= mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 2f || transform.position.y <= mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 2f)
        {
            Destroy(gameObject);
        }
        transform.Translate(new Vector2(horiSpeed * Time.deltaTime, vertSpeed * Time.deltaTime));
	}
}
