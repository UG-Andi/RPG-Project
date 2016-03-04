using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fightsystem : MonoBehaviour {

    [Header("Gameobjects")]
    public GameObject fireball;

    [Header("Variable")]
    public float endurance;
    public float maxEndurance;
    public float enduranceGain;
    public float fireballEndurance;

    private bool shooted;
    private Slider enduranceSlider;

	// Use this for initialization
	void Start ()
    {
        shooted = false;
        GameObject.Find("EnduranceSlider");
    }
	
	// Update is called once per frame
	void Update ()
    {
        enduranceSlider.value = endurance;

        if (endurance < maxEndurance)
        {
            endurance += enduranceGain;
        }

        if (Input.GetButtonDown("Attack") && shooted == false && endurance > fireballEndurance)
        {
            shooted = true;
            Instantiate(fireball);
            endurance -= fireballEndurance;
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
