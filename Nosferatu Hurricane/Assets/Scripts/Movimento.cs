using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidade = 4f;
    public float velRotacao = 10f;
    public GameObject levelManager;
    public GameObject footstepEffects;
    public float footstepInterval;
    public LayerMask guardLayerMask;
    public RatControl ratControl;
    public ShadowControl shadowControl;
    public PsychicControl psychicControl;

    Vector3 direcao = Vector3.zero;
    CharacterController controller;
    private float footstepTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        ratControl = FindObjectOfType<RatControl>();
        shadowControl = FindObjectOfType<ShadowControl>();
        psychicControl = FindObjectOfType<PsychicControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && !LevelManager.levelComplete && !LevelManager.levelFailed && !ratControl.ControlRat && !shadowControl.ControlShadow && !psychicControl.activateTimer)
        {
            Andar();
        }

        transform.forward = Vector3.RotateTowards(transform.forward, direcao, velRotacao * Time.deltaTime, 0.0f);

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void Andar()
    {

        direcao = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direcao = Vector3.ClampMagnitude(direcao, 1);
        direcao *= velocidade;

        controller.Move(direcao * Time.deltaTime);

        if(footstepTimer <= 0)
        {
            Instantiate(footstepEffects, transform.position, Quaternion.identity);
            footstepTimer = footstepInterval;
        }
        else
        {
            footstepTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Detection"))
        {
            GameObject guard = outro.transform.parent.gameObject;
            Vector3 guardDirection = transform.position - guard.transform.position;
            Ray ray = new Ray(guard.transform.position, guardDirection.normalized);
            Debug.DrawRay(ray.origin, ray.direction * 15, Color.magenta);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 15, ~guardLayerMask))
            {
                if (hit.transform == transform)
                {
                        levelManager.GetComponent<LevelManager>().PlayerDetected();
                }
            }
        }
    }
}
