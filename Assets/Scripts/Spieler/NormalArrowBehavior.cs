using UnityEngine;
using System.Collections;

public class NormalArrowBehavior : MonoBehaviour
{
    // Referenzen
    private GameObject player;
    // Floats
    [Header("Settings")]
    public float speed;
    public float rotationAngle;

    public float timer = 0.1f;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

        if (timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
        }

        if (timer < 0.0f)
        {
            transform.Rotate(new Vector3(transform.rotation.x + rotationAngle / 100, 0, 0), Space.Self);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }
}
