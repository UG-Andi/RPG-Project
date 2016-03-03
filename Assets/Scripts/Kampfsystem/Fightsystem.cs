using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fightsystem : MonoBehaviour {

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
    }
	
	// Update is called once per frame
	void Update ()
    {
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
}
