using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Player Related")]
    public GameObject player;
    private BNG.SmoothLocomotion playerLocomotion;
    private BNG.PlayerRotation playerRotation;
    private Vector3 playerInitialPosition;
    private Quaternion playerInitialRotation;

    [Header("Welcome Related")]
    public GameObject welcomePanel;

    [Header("Controller Related")]
    public GameObject mechanicPanel;

    [Header("Move Related")]
    public GameObject movePanel;
    public GameObject moveArea;

    private void Awake() {
        playerLocomotion = player.GetComponent<BNG.SmoothLocomotion>();
        playerRotation = player.GetComponent<BNG.PlayerRotation>();

        playerInitialPosition = player.transform.position;
        playerInitialRotation = player.transform.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        AllowMoveAndRotate(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AllowMoveAndRotate(bool boolean)
    {
        if (!boolean)
        {
            playerLocomotion.DisableMovement();
            playerRotation.AllowInput = false;
        }
        else
        {
            playerLocomotion.EnableMovement();
            playerRotation.AllowInput = true;
        }
    }

    private void ResetPositionAndRotation()
    {
        player.transform.position = playerInitialPosition;
        player.transform.rotation = playerInitialRotation;
    }

    // UI Related
    public void OnWelcomeNext()
    {
        welcomePanel.SetActive(false);

        mechanicPanel.SetActive(true);
    }

    public void OnMechanicBack()
    {
        mechanicPanel.SetActive(false);

        welcomePanel.SetActive(true);
    }

    public void OnMechanicNext()
    {
        mechanicPanel.SetActive(false);

        movePanel.SetActive(true);
        moveArea.SetActive(true);

        AllowMoveAndRotate(true);
    }

    public void OnMoveBack()
    {
        ResetPositionAndRotation();

        movePanel.SetActive(false);
        moveArea.SetActive(false);

        mechanicPanel.SetActive(true);
    }
}
