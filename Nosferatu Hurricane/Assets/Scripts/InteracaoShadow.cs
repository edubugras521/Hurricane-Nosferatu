using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteracaoShadow : MonoBehaviour
{

    private GameObject targetObject;
    private bool temChave = false;

    public int interactRange = 2;
    public GameObject Shadow;
    public GameObject levelManager;
    public Text InspectText;


    // Update is called once per frame
    void Update()
    {
        InteractCheck();
    }

    void InteractCheck()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, interactRange))
        {
            if (hit.collider.CompareTag("Door"))
            {
                targetObject = hit.collider.gameObject;
                InspectText.text = "[E]: Abrir Porta";

                if (Input.GetButtonDown("Interact"))
                {
                    targetObject.GetComponent<DoorControl>().ToggleDoor();
                }
            }

            if (hit.collider.CompareTag("DoorLocked"))
            {
                targetObject = hit.collider.gameObject;

                if (!temChave)
                {
                    InspectText.text = "Porta Trancada";
                    if (Input.GetButtonDown("Interact"))
                    {
                        targetObject.GetComponent<DoorControl>().ToggleLockedDoor();
                    }
                }

                if (temChave)
                {
                    InspectText.text = "[E]: Abrir Porta";

                    if (Input.GetButtonDown("Interact"))
                    {
                        targetObject.GetComponent<DoorControl>().ToggleDoor();
                    }
                }
            }

            if (hit.collider.CompareTag("Wall"))
            {
                InspectText.text = "";
            }
        }

        else
        {
            InspectText.text = "";
        }
    }
}

