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
    public float rotSpeed;

    //Vectors
    private Vector3 targetDir;

    //Bool
    private bool canTurnRight = true;
    private bool canTurnLeft = true;

    void Start()
    {
        cam = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Vorwärtsbewegung (Kamera etc)
        // Vertikal
        if (v > 0.1f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

            targetDir = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

            Vector3 playerRot = Vector3.RotateTowards(transform.forward, targetDir, rotSpeed * Time.deltaTime, 5.0f);

            transform.rotation = Quaternion.LookRotation(playerRot);
        }

        if (v < -0.1f)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime, Space.Self);

            Vector3 targetDir = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);
            Vector3 playerRot = Vector3.RotateTowards(transform.forward, targetDir, rotSpeed * Time.deltaTime, 5.0f);

            transform.rotation = Quaternion.LookRotation(playerRot);

            canTurnRight = true;
            canTurnLeft = true;
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

        Vector3 shootDir = transform.forward;
        // Schießen
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                Instantiate(arrow, arrowSpawn.position, Quaternion.LookRotation(shootDir));
        }
    }
}
