using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowControl : MonoBehaviour
{
    public bool ControlShadow;
    private CharacterController shadowController;
    private GameObject Player;
    private CapsuleCollider shadowCollider;
    private InteracaoShadow interacaoShadow;
    private EnemyEffects enemyControl;

    Vector3 directionShadow = Vector3.zero;

    public float shadowVelocity;
    public float shadowVelRotacao;

    public GameObject shadowFOV;
    public GameObject playerFOV;

    public RatControl ratControl;
    public PsychicControl psychicControl;

    private BloodBar bloodBar;
    public float shadowAi = -0.5f;

    // Start is called before the first frame update
    void Start()
    {
        shadowAi = PlayerPrefs.GetFloat("ShadowAi");
        shadowController = GetComponent<CharacterController>();
        shadowCollider = GetComponent<CapsuleCollider>();
        interacaoShadow = GetComponent<InteracaoShadow>();
        Player = GameObject.Find("Player");

        interacaoShadow.enabled = false;

        bloodBar = FindObjectOfType<BloodBar>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !ControlShadow && !ratControl.ControlRat && !psychicControl.activateTimer && bloodBar.BloodLeft > 0)
        {
            ControlShadow = true;
            shadowCollider.enabled = true;
            Player.GetComponent<Interacao>().enabled = false;
            interacaoShadow.enabled = true;
            shadowFOV.SetActive(true);
            playerFOV.SetActive(false);
            StartCoroutine("ShadowBloodDrain");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && ControlShadow && !ratControl.ControlRat && !psychicControl.activateTimer && bloodBar.BloodLeft > 0)
        {
            ControlShadow = false;
            shadowCollider.enabled = false;
            Player.GetComponent<Interacao>().enabled = true;
            interacaoShadow.enabled = false;
            shadowFOV.SetActive(false);
            playerFOV.SetActive(true);
            StopCoroutine("ShadowBloodDrain");
        }

        if (ControlShadow)
        {
            directionShadow = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            directionShadow = Vector3.ClampMagnitude(directionShadow, 1);
            directionShadow *= shadowVelocity;

            shadowController.Move(directionShadow * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
            transform.rotation = Player.transform.rotation;
            StopCoroutine("ShadowBloodDrain");
        }

        transform.forward = Vector3.RotateTowards(transform.forward, directionShadow, shadowVelRotacao * Time.deltaTime, 0.0f);

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public IEnumerator ShadowBloodDrain()
    {
        while (true)
        {
            bloodBar.BloodLeft -= 0.03f;
            shadowAi += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Guard") && ControlShadow)
        {
            ControlShadow = false;
            shadowCollider.enabled = false;
            shadowFOV.SetActive(false);
            playerFOV.SetActive(true);
            shadowAi += 5;
        }
    }
}
