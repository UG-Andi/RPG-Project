using UnityEngine;
using System.Collections;

public class NormalArrowBehavior : MonoBehaviour
{
    // Referenzen
    private GameObject player;
<<<<<<< HEAD
    

=======
    // Floats
>>>>>>> origin/master
    [Header("Settings")]
    public float speed;
    public float rotationAngle;

    public float timer = 0.1f;

<<<<<<< HEAD
    [Header("Battle")]
    public int damage;

=======
>>>>>>> origin/master
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
<<<<<<< HEAD
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Enemy>().GetDamage(damage);
        }

=======
>>>>>>> origin/master
        Destroy(gameObject);
    }
}
