using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatControl : MonoBehaviour
{
    public bool ControlRat;
    private CharacterController ratController;
    private GameObject Player;
    private BoxCollider ratCollider;
    private EnemyControl enemyControl;

    Vector3 directionRat = Vector3.zero;

    public float ratVelocity;
    public float ratVelRotacao;

    // Start is called before the first frame update
    void Start()
    {
        ratController = GetComponent<CharacterController>();
        ratCollider = GetComponent<BoxCollider>();
        Player = GameObject.Find("Player");
        enemyControl = FindObjectOfType<EnemyControl>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, directionRat, ratVelRotacao * Time.deltaTime, 0.0f);

        if (Input.GetKeyDown(KeyCode.LeftControl) && !ControlRat)
        {
            ControlRat = true;
            ratCollider.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && ControlRat)
        {
            ControlRat = false;
            ratCollider.enabled = false;
        }

        if (ControlRat)
        {
            directionRat = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            directionRat = Vector3.ClampMagnitude(directionRat, 1);
            directionRat *= ratVelocity;

            ratController.Move(directionRat * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3 (Player.transform.position.x,transform.position.y,Player.transform.position.z);
            transform.rotation = Player.transform.rotation;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Detection"))
        {
            enemyControl.followRat = true;
        }
        if (other.gameObject.CompareTag("Guard"))
        {
            ControlRat = false;
            ratCollider.enabled = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Detection"))
        {
            enemyControl.followRat = false;
        }
    }
}
