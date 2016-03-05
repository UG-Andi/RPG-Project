using UnityEngine;
using System.Collections;

public class Enemy_Archer : Enemy 
{

    [Header("Archer Battle")]
    public float shootingRange;

    public float arrowCooldown;
    private float arrowTimer;
    public GameObject arrow;
    public Transform arrowSpawn;

    // Booleans
    private bool canShoot;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        canvas = GetComponentInChildren<Canvas>();
        cam = Camera.main;

        // Werte werden gesetzt
        healthSlider.maxValue = maxHealth;
        currentHealth = maxHealth;

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

        Vector3 lookDir = player.transform.position - transform.position;
        transform.LookAt(player.transform.localPosition);

        if (Vector3.Distance(transform.localPosition, player.transform.localPosition) < distance)
        {
            if (Vector3.Distance(transform.localPosition, player.transform.localPosition) > navMeshAgent.stoppingDistance -1)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }
            else
            {
                transform.Translate(Vector3.back * 3 * Time.deltaTime);
            }
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

        // Fighting System

        RaycastHit shootHit;
        Debug.DrawLine(transform.localPosition, lookDir * shootingRange, Color.red);

        if (Physics.Raycast(transform.localPosition, lookDir, out shootHit, shootingRange))
        {
            if (shootHit.collider.gameObject.CompareTag("Player")) { canShoot = true; } else { canShoot = false; }
        }

        if (arrowTimer > 0)
        {
            arrowTimer -= Time.deltaTime;
        }

        
        // Checkt Bedingungen für Schießen
        if (Vector3.Distance(transform.localPosition, player.transform.localPosition) < shootingRange && arrowTimer <= 0)
        {

            Instantiate(arrow, arrowSpawn.position, Quaternion.LookRotation(lookDir));
            arrowTimer = arrowCooldown;
        }
    }

    public void GetDamage(int _damage)
    {
        currentHealth -= _damage;
    }
}

