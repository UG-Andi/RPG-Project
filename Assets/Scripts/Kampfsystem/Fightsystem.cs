using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fightsystem : MonoBehaviour {

<<<<<<< HEAD
    public float energy;
    public float punchEnergy;
    private bool shoot;
    public GameObject fireball;

	// Use this for initialization
	void Start ()
    {
        energy = 0.5f;
=======
    [Header("Gameobjects")]
    public GameObject fireball;

    [Header("Variable")]
    public float energy;
    public float energyGain;
    public float fireballEnergy;
    private bool shooted;

	// Use this for initialization
	void Start ()
    {
        shooted = false;
>>>>>>> origin/master
    }
	
	// Update is called once per frame
	void Update ()
    {
<<<<<<< HEAD
        Shoot();
        energy += 0.001f;
        if (Input.GetButtonDown("Attack"))
        {
            shoot = true;
        }
	}

    void Shoot ()
    {
        if (shoot == true)
        {
            Instantiate(fireball);
            fireball.transform.Translate(Vector3.right * Time.deltaTime);
            shoot = false;
        }
    }
=======
        if (energy < 1)
        {
            energy += 0.001f;
        }

        if (Input.GetButtonDown("Attack") && shooted == false && energy > fireballEnergy)
        {
            shooted = true;
            Instantiate(fireball);
            energy -= fireballEnergy;
        }

        GameObject flyingFireball = GameObject.Find("Fireball(Clone)");

        if (shooted == true)
        {
            flyingFireball.GetComponent<Rigidbody>().AddForce(Vector3.right * 100);
            if (flyingFireball.transform.position.y <= 0)
            {
                Destroy(flyingFireball);
                shooted = false;
            }
        }
        
        
	}
>>>>>>> origin/master
}
