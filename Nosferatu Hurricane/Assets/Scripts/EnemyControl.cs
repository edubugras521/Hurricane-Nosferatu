using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject player;
    public GameObject rat;
    public GameObject levelManager;
    public float rotacao;
    public float range;
    public LayerMask playerLayer;
    public LayerMask ratLayer;

    public float timer;
    public bool activateTimer;

    private Transform guard;
    private Renderer enemyRenderer;

    public bool followRat;
    public int followSpeed;

    private void Start()
    {
        guard = GetComponent<Transform>();
        enemyRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector3 direcao = player.transform.position - guard.position;
        Ray raio = new Ray(guard.position, direcao.normalized);
        Debug.DrawRay(raio.origin, raio.direction * 30, Color.magenta);
        RaycastHit hit;
        if (Physics.Raycast(raio, out hit, range, playerLayer))
        {
            if (hit.transform == player.transform)
            {
                if (Vector3.Angle(raio.direction, guard.forward) < 30)
                {
                    levelManager.GetComponent<LevelManager>().PlayerDetected();
                }
            }
        }

        if (activateTimer)
        {
            timer += Time.deltaTime;
        }

        if(timer >= 2)
        {
            activateTimer = false;
            timer = 0;
            enemyRenderer.material.color = Color.blue;
        }

        if (followRat)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(rat.transform.position.x, transform.position.y, rat.transform.position.z), followSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Psychic"))
        {
            enemyRenderer.material.color = Color.red;
            activateTimer = true;
        }
    }
}
