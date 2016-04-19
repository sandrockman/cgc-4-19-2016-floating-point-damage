using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingPointsScript : MonoBehaviour {

    public GameObject criticalImage;
    public Text damagePoints;
    public string chestDamage;
    public string legDamage;
    public string headDamage;
    private Animator anim;
    private Animator animHead;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        anim = damagePoints.GetComponent<Animator>();
        animHead = criticalImage.GetComponent<Animator>();
        damagePoints = damagePoints.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        FloatingDamage();
	}

    void FloatingDamage()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        int rayLength = 20;
        Debug.DrawRay(transform.position, fwd * rayLength, Color.green);

        if(Input.GetButtonDown("Fire1") && Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            if(hit.transform.tag == "LegDmg")
            {
                anim.SetTrigger("Dmg");
                damagePoints.text = legDamage;
            }
            if(hit.transform.tag == "ChestDmg")
            {
                anim.SetTrigger("Dmg");
                damagePoints.text = chestDamage;
            }
            if(hit.transform.tag == "HeadDmg")
            {
                anim.SetTrigger("Dmg");
                animHead.SetTrigger("Head");
                damagePoints.text = headDamage;
            }
        }
    }
}
