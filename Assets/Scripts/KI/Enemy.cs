using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> origin/master

public class Enemy : MonoBehaviour
{

    // Referenzen
    private NavMeshAgent navMeshAgent;
    private GameObject player;
<<<<<<< HEAD
    private Camera cam;
=======
>>>>>>> origin/master

    [Header("Settings")]
    public float speed;
    public float distance;

<<<<<<< HEAD
    public enum TypeOfEnemy { Normal }
    public TypeOfEnemy Type;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Battle")]
    public int physicalDamage;
    public int magicalDamage;

    [Header("UI")]
    public float showUI;
    public float UITimer;

    private Canvas canvas;
    private Slider healthSlider;
    public Text typeText;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        healthSlider = GetComponentInChildren<Slider>();
        canvas = GetComponentInChildren<Canvas>();

        player = GameObject.Find("Player");
        cam = Camera.main;

        // Werte werden gesetzt
        currentHealth = maxHealth;

        canvas.enabled = false;
=======
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player");

>>>>>>> origin/master
    }

    void Update()
    {
<<<<<<< HEAD
        healthSlider.value = currentHealth;

=======
>>>>>>> origin/master
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            Vector3 lookDir = player.transform.position - transform.position;
            Quaternion.LookRotation(lookDir);

            navMeshAgent.SetDestination(player.transform.position);
        }
<<<<<<< HEAD

        // Set UI
        typeText.text = Type.ToString();

        if (UITimer > 0)
        {
            UITimer -= Time.deltaTime;
            canvas.enabled = true;
        }
        else
        {
            UITimer = 0;
            canvas.enabled = false;
        }
        // Kill Enemy
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        canvas.transform.LookAt(cam.transform.position);
    }

    public void GetDamage(int _damage)
    {
        currentHealth -= _damage;
=======
>>>>>>> origin/master
    }
}