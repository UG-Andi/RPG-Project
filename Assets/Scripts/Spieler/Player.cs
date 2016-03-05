﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Referenzen
    public GameObject arrow;
    public Transform arrowSpawn;

    private Camera cam;
    private Rigidbody rigidbody;

    //Floats
    [Header("Movement")]
    public float speed;
    public float shiftBoost;
    public float currentSpeed;
    public float rotSpeed;

    void Start()
    {
        cam = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Maus-Settigns
        UnityEngine.Cursor.visible = false;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Vorwärtsbewegung (Kamera etc)
        // Vertikal
        if (v > 0.1f)
        {
            currentSpeed = speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed *= shiftBoost;
                transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
            }
            else
            {
                transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime, Space.Self);
            }
        }

        if (v < -0.1f)
        {
            currentSpeed = speed;

            transform.Translate(Vector3.forward * -currentSpeed * Time.deltaTime, Space.Self);
        }

        if (!Input.GetKey(KeyCode.Mouse2))
        {
            Vector3 targetDir = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);
            Vector3 playerRot = Vector3.RotateTowards(transform.forward, targetDir, rotSpeed * Time.deltaTime, 5.0f);

            transform.rotation = Quaternion.LookRotation(playerRot);
        }

        // Horizontal

        if (h > 0.1f)
        {
            transform.Translate(Vector3.right * speed * 0.75f * Time.deltaTime, Space.Self);
        }

        if (h < -0.1f)
        {
            transform.Translate(Vector3.left * speed * 0.75f * Time.deltaTime, Space.Self);
        }

        // Diagonal
        if (h > 0.1f && v > 0.1f || h < -0.1f && v > 0.1f || h > 0.1f && v < -0.1f || h < -0.1f && v < -0.1f)
        {
            currentSpeed = speed / 2;
        }

        Vector3 shootDir = transform.forward;
        // Schießen
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
                Instantiate(arrow, arrowSpawn.position, Quaternion.LookRotation(shootDir));
        }
    }
}
