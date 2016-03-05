using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.UI;
=======
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> origin/master
>>>>>>> origin/master

public class Enemy : MonoBehaviour
{

    // Referenzen
<<<<<<< HEAD
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public Camera cam;

    [Header("Settings")]
    public float distance;

    public enum TypeOfEnemy { Normal, Archer }
=======
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
>>>>>>> origin/master
    public TypeOfEnemy Type;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Battle")]
    public int physicalDamage;
    public int magicalDamage;
<<<<<<< HEAD
    public bool activateUI;

    [Header("UI")]
    public Text EnemyName;
    public string name;
    public float UIDistance;
    public string[] potentialNames;

    public Canvas canvas;
    public Slider healthSlider;
=======

    [Header("UI")]
    public float showUI;
    public float UITimer;

    private Canvas canvas;
    private Slider healthSlider;
>>>>>>> origin/master
    public Text typeText;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
<<<<<<< HEAD
=======
        healthSlider = GetComponentInChildren<Slider>();
>>>>>>> origin/master
        canvas = GetComponentInChildren<Canvas>();

        player = GameObject.Find("Player");
        cam = Camera.main;

        // Werte werden gesetzt
<<<<<<< HEAD
        healthSlider.maxValue = maxHealth;
        currentHealth = maxHealth;

        canvas.enabled = false;

        // Namensgebung

        if (potentialNames[0] != null)
        {
            int nameListLength = potentialNames.Length;
            int randomName = Random.Range(0, nameListLength);
            name = potentialNames[randomName];

            EnemyName.text = name;
        }
=======
        currentHealth = maxHealth;

        canvas.enabled = false;
=======
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player");

>>>>>>> origin/master
>>>>>>> origin/master
    }

    void Update()
    {
<<<<<<< HEAD
        healthSlider.value = currentHealth;

        if (Vector3.Distance(transform.localPosition, player.transform.localPosition) < distance)
=======
<<<<<<< HEAD
        healthSlider.value = currentHealth;

=======
>>>>>>> origin/master
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
>>>>>>> origin/master
        {
            Vector3 lookDir = player.transform.position - transform.position;
            Quaternion.LookRotation(lookDir);

            navMeshAgent.SetDestination(player.transform.position);
        }
<<<<<<< HEAD

        // UI-Aktivierung
        if (Vector3.Distance(transform.localPosition, player.transform.localPosition) < UIDistance)
        {
            activateUI = true;
        }
        else
        {
            activateUI = false;
        }


        if (activateUI)
        {
=======
<<<<<<< HEAD

        // Set UI
        typeText.text = Type.ToString();

        if (UITimer > 0)
        {
            UITimer -= Time.deltaTime;
>>>>>>> origin/master
            canvas.enabled = true;
        }
        else
        {
<<<<<<< HEAD
            canvas.enabled = false;
        }

        typeText.text = Type.ToString();

=======
            UITimer = 0;
            canvas.enabled = false;
        }
>>>>>>> origin/master
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
<<<<<<< HEAD
=======
=======
>>>>>>> origin/master
>>>>>>> origin/master
    }
}