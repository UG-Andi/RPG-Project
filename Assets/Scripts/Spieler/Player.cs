using UnityEngine;
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
<<<<<<< HEAD
    private float currentSpeed;
    public float rotSpeed;

    //Vectors
    public Vector3 targetDir;
=======
<<<<<<< HEAD
    private float currentSpeed;

=======
>>>>>>> origin/master
    public float rotSpeed;

    //Vectors
    private Vector3 targetDir;
>>>>>>> origin/master

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
<<<<<<< HEAD
            currentSpeed = speed;

            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
=======
<<<<<<< HEAD
            currentSpeed = speed;

            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
=======
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

            targetDir = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);

            Vector3 playerRot = Vector3.RotateTowards(transform.forward, targetDir, rotSpeed * Time.deltaTime, 5.0f);

            transform.rotation = Quaternion.LookRotation(playerRot);
>>>>>>> origin/master
>>>>>>> origin/master
        }

        if (v < -0.1f)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> origin/master
            currentSpeed = speed;

            transform.Translate(Vector3.forward * -speed * Time.deltaTime, Space.Self);
        }

        if (!Input.GetKey(KeyCode.Mouse2))
        {
<<<<<<< HEAD
=======
=======
            transform.Translate(Vector3.forward * -speed * Time.deltaTime, Space.Self);

>>>>>>> origin/master
>>>>>>> origin/master
            Vector3 targetDir = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);
            Vector3 playerRot = Vector3.RotateTowards(transform.forward, targetDir, rotSpeed * Time.deltaTime, 5.0f);

            transform.rotation = Quaternion.LookRotation(playerRot);
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

            canTurnRight = true;
            canTurnLeft = true;
>>>>>>> origin/master
>>>>>>> origin/master
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

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> origin/master
        // Diagonal
        if (h > 0.1f && v > 0.1f || h < -0.1f && v > 0.1f || h > 0.1f && v < -0.1f || h < -0.1f && v < -0.1f)
        {
            currentSpeed = speed / 2;
        }

<<<<<<< HEAD
=======
=======
>>>>>>> origin/master
>>>>>>> origin/master
        Vector3 shootDir = transform.forward;
        // Schießen
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                Instantiate(arrow, arrowSpawn.position, Quaternion.LookRotation(shootDir));
        }
<<<<<<< HEAD

        // Raycast vorwärts
        RaycastHit hit;

        if (Physics.Raycast(transform.localPosition, Vector3.forward, out hit, 7))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Enemy>().UITimer = hit.collider.gameObject.GetComponent<Enemy>().showUI;
            }
        }
=======
>>>>>>> origin/master
    }
}
