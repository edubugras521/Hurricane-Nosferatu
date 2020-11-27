using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidade = 4f;
    public float velRotacao = 10f;
    public Animator animator;
    public GameObject levelManager;
    public GameObject footstepEffects;
    public float footstepInterval;
    public LayerMask guardLayerMask;
    public RatControl ratControl;
    public ShadowControl shadowControl;
    public PsychicControl psychicControl;
    public float detectionScaleWhenLit;
    public CanvasGroup litOverlay;

    public bool isInLight = false;
    private GameObject[] guardfovs;
    private float footstepTimer = 0;
    private float cocadinhaTimer;
    private float cocadinhaIntervalo;
    private bool godMode = false;

    Vector3 direcao = Vector3.zero;
    CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        ratControl = FindObjectOfType<RatControl>();
        shadowControl = FindObjectOfType<ShadowControl>();
        psychicControl = FindObjectOfType<PsychicControl>();
        guardfovs = GameObject.FindGameObjectsWithTag("Detection");
        cocadinhaIntervalo = Random.Range(10.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && !LevelManager.levelComplete && !LevelManager.levelFailed && !ratControl.ControlRat && !shadowControl.ControlShadow && !psychicControl.activateTimer)
        {
            Andar();
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
            if(cocadinhaTimer > 0)
            {
                cocadinhaTimer -= Time.deltaTime;
                cocadinhaTimer = Mathf.Clamp(cocadinhaTimer, 0, cocadinhaIntervalo);
                animator.SetFloat("cocadinha_timer", cocadinhaTimer);
            }
            else
            {
                cocadinhaIntervalo = Random.Range(5.0f, 20.0f);
                cocadinhaTimer = cocadinhaIntervalo;
                animator.SetFloat("cocadinha_timer", cocadinhaTimer);
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            godMode = !godMode;
        }

        transform.forward = Vector3.RotateTowards(transform.forward, direcao, velRotacao * Time.deltaTime, 0.0f);

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if (isInLight)
        {
            foreach (GameObject guardfov in guardfovs)
            {
                guardfov.transform.localScale = new Vector3(detectionScaleWhenLit, detectionScaleWhenLit, detectionScaleWhenLit);
            }

            if(litOverlay.alpha < 1)
            {
                litOverlay.alpha += Time.deltaTime;
                Mathf.Clamp(litOverlay.alpha, 0, 1);
            }
        }
        else
        {
            foreach (GameObject guardfov in guardfovs)
            {
                guardfov.transform.localScale = new Vector3(1, 1, 1);
            }

            if (litOverlay.alpha > 0)
            {
                litOverlay.alpha -= Time.deltaTime;
                Mathf.Clamp(litOverlay.alpha, 0, 1);
            }
        }
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
        if (outro.CompareTag("Detection") && !godMode)
        {
            GameObject guard = outro.transform.parent.gameObject;
            bool guardTerrified = guard.GetComponent<EnemyController>().IsGuardTerrified();
            Vector3 guardDirection = transform.position - guard.transform.position;
            Ray ray = new Ray(guard.transform.position, guardDirection.normalized);
            Debug.DrawRay(ray.origin, ray.direction * 15, Color.magenta);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 15, ~guardLayerMask))
            {
                if (hit.transform == transform && !guardTerrified)
                {
                        levelManager.GetComponent<LevelManager>().PlayerDetected();
                }
            }
        }
    }

    private void OnTriggerStay(Collider outro)
    {
        if (outro.CompareTag("Light"))
        {
            GameObject candle = outro.transform.parent.gameObject;
            if (candle.GetComponent<CandleControl>().IsLit())
            {
                isInLight = true;
            }
            else
            {
                isInLight = false;
            }
        }
    }

    private void OnTriggerExit(Collider outro)
    {
        if (outro.CompareTag("Light"))
        {
            isInLight = false;
        }
    }
}
