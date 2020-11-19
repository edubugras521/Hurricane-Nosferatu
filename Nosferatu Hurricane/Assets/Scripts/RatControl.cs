using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatControl : MonoBehaviour
{
    public bool ControlRat;
    private CharacterController ratController;
    private GameObject Player;
    private BoxCollider ratCollider;
    private EnemyEffects enemyControl;

    Vector3 directionRat = Vector3.zero;

    public float ratVelocity;
    public float ratVelRotacao;

    public GameObject ratFOV;
    public GameObject playerFOV;

    public ShadowControl shadowControl;
    public PsychicControl psychicControl;

    private BloodBar bloodBar;
    public float ratAi = -0.5f;

    // Start is called before the first frame update
    void Start()
    {
        ratAi = PlayerPrefs.GetFloat("RatAi");
        ratController = GetComponent<CharacterController>();
        ratCollider = GetComponent<BoxCollider>();
        Player = GameObject.Find("Player");
        enemyControl = FindObjectOfType<EnemyEffects>();
        bloodBar = FindObjectOfType<BloodBar>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, directionRat, ratVelRotacao * Time.deltaTime, 0.0f);

        if (Input.GetKeyDown(KeyCode.LeftControl) && !ControlRat && !shadowControl.ControlShadow && !psychicControl.activateTimer && bloodBar.BloodLeft > 0)
        {
            ControlRat = true;
            ratCollider.enabled = true;
            ratFOV.SetActive(true);
            playerFOV.SetActive(false);
            StartCoroutine("RatBloodDrain");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && ControlRat && !shadowControl.ControlShadow && !psychicControl.activateTimer && bloodBar.BloodLeft > 0)
        {
            ControlRat = false;
            ratCollider.enabled = false;
            ratFOV.SetActive(false);
            playerFOV.SetActive(true);
            StopCoroutine("RatBloodDrain");
        }

        if (ControlRat)
        {
            directionRat = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            directionRat = Vector3.ClampMagnitude(directionRat, 1);
            directionRat *= ratVelocity;

            ratController.Move(directionRat * Time.deltaTime);
            transform.position = new Vector3 (transform.position.x, -0.8f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3 (Player.transform.position.x, -2, Player.transform.position.z);
            transform.rotation = Player.transform.rotation;
            StopCoroutine("RatBloodDrain");
        }

        if (bloodBar.BloodLeft <= 0)
        {
            ControlRat = false;
            shadowControl.ControlShadow = false;
            psychicControl.timer = 2;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Detection") && ControlRat)
        {
            enemyControl.followRat = true;
        }
        if (other.gameObject.CompareTag("Guard") && ControlRat)
        {
            ControlRat = false;
            ratCollider.enabled = false;
            ratFOV.SetActive(false);
            playerFOV.SetActive(true);
            ratAi += 4;
        }
        if (other.gameObject.CompareTag("Rat Traps") && ControlRat)
        {
            ControlRat = false;
            ratCollider.enabled = false;
            ratFOV.SetActive(false);
            playerFOV.SetActive(true);
            ratAi += 2;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Detection"))
        {
            enemyControl.followRat = false;
        }
    }

    public IEnumerator RatBloodDrain()
    {
        while (true)
        {
            bloodBar.BloodLeft -= 0.03f;
            ratAi += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
