using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {
    public Camera mainCam;

    public GameObject asteroid;

    public BoxCollider2D topWall, botWall;
    public BoxCollider2D leftWall, rightWall;

    void Start()
    {
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        botWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2, 0f, 0f)).x, 1f);
        botWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        InvokeRepeating("SpawnAsteroid", 0f, 1f);
    }

    void SpawnAsteroid()
    {
        Vector2 spawn;
        int alignInt = (int)Random.Range(0, 2);
        int sideInt = (int)Random.Range(0, 2);
        float x, y, rotateZ;

        if (alignInt == 0)
        {
            x = Random.Range(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x, mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x);
            
            if (sideInt == 0)
            {
                y = mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y;
                rotateZ = Random.Range(-45f, 45f);
            }
            else
            {
                y = mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
                rotateZ = Random.Range(135f, 225f);
            }
        }
        else
        {
            y = Random.Range(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y);

            if (sideInt == 0)
            {
                x = mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x;
                rotateZ = Random.Range(250f, 270f);
            }
            else
            {
                x = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
                rotateZ = Random.Range(70f, 110f);
            }
        }

        spawn = new Vector2(x, y);

        Instantiate(asteroid, spawn, Quaternion.Euler(0f, 0f, rotateZ));
    }
}
