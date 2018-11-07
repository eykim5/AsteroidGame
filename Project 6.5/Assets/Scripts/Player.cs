using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 2f;
    public float rotateSpeed = 3f;
    public float thrustSpeed = 4f;
    public GameObject bullet;
    private GameObject fire;
    private GameObject gun;
    public AudioClip laserClip;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        fire = GameObject.Find("Thrust");
        gun = GameObject.Find("Gun");
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        float thrustVal = 1f;
        float horiInput = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump"))
        {
            thrustVal = thrustSpeed;
            fire.SetActive(true);
        }
        else
        {
            thrustVal = 1f;
            fire.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Invoke("Fire", 0f);
        }

        transform.Translate(new Vector3(0f, (thrustVal * speed) * Time.deltaTime, 0f));
        transform.Rotate(new Vector3(0f, 0f, horiInput * rotateSpeed * -1));
	}

    void Fire()
    {
        audioSource.PlayOneShot(laserClip);
        Instantiate(bullet, gun.transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathObj" || collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
