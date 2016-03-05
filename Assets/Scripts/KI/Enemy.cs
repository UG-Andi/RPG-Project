using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    // Referenzen
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public Camera cam;

    [Header("Settings")]
    public float distance;

    public enum TypeOfEnemy { Normal, Archer }
    public TypeOfEnemy Type;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Battle")]
    public int physicalDamage;
    public int magicalDamage;
    public bool activateUI;

    [Header("UI")]
    public Text EnemyName;
    public string name;
    public float UIDistance;
    public string[] potentialNames;

    public Canvas canvas;
    public Slider healthSlider;
    public Text typeText;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        canvas = GetComponentInChildren<Canvas>();

        player = GameObject.Find("Player");
        cam = Camera.main;

        // Werte werden gesetzt
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
    }

    void Update()
    {
        healthSlider.value = currentHealth;

        if (Vector3.Distance(transform.localPosition, player.transform.localPosition) < distance)
        {
            Vector3 lookDir = player.transform.position - transform.position;
            Quaternion.LookRotation(lookDir);

            navMeshAgent.SetDestination(player.transform.position);
        }

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
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }

        typeText.text = Type.ToString();

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
    }
}