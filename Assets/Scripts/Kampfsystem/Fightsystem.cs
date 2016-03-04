using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fightsystem : MonoBehaviour {

    public float energy;
    public float punchEnergy;
    private bool shoot;
    public GameObject fireball;

	// Use this for initialization
	void Start ()
    {
        energy = 0.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
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
}
