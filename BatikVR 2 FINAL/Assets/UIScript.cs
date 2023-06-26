using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject gameModePanel;
    public GameObject canting;
    public GameObject player;
    private BNG.SmoothLocomotion playerLocomotion;
    private BNG.PlayerRotation playerRotation;
    private Vector3 cantingInitialPosition;
    private Quaternion cantingInitialRotation;
    private Vector3 gameInitialPosition;
    Rigidbody rb1;

    [Header("Sinau Related")]
    public GameObject sinauPanel;

    [Header("Kuis Related")]
    public Button kuisButton;
    public GameObject kuisPanel;
    public GameObject kuisInfoPanel;
    public GameObject question1Panel;
    public GameObject question2Panel;
    public GameObject question3Panel;
    public GameObject question4Panel;
    public GameObject question5Panel;
    public GameObject completeKuisPanel;
    public GameObject failKuisPanel;
    public Text scoreTextComplete;
    public Text scoreTextFail;
    private int score = 0;
    private bool kuisCompleted = false;

    [Header("Ngebatik Related")]
    public Button ngebatikButton;
    public GameObject ngebatikPanel;
    public GameObject ngebatikPause1;
    public GameObject ngebatikPause2;
    public GameObject ngebatikGame;
    public Text timerText;
    public GameObject readyButton;
    public GameObject submitButton;
    public GameObject pauseButtonGO;
    public Button pauseButton;
    public GameObject cariCantingButton;
    public GameObject hasilPanel;
    public Text hasilDescription;
    public Image bintang1;
    public Image bintang2;
    public Image bintang3;
    [Tooltip("Input time for the timer in seconds")] public float timeLeft;
    public Toggle controllerTog;
    public Toggle handTrackTog;
    public Toggle reversedTog;
    private float countDown;
    private bool timerOn = false;
    private Color full;
    private Color notFull;

    [Header("Toko Related")]
    public GameObject webViewPanel;
    public GameObject keyboard;
    public GameObject webViewClosePanel;

    [Header("Batik Mode Hand")]
    public GameObject controllerLeft;
    public GameObject controllerRight;
    public GameObject handVisualizer;

    // Start is called before the first frame update
    void Start()
    {
        kuisButton.enabled = false;

        ngebatikButton.enabled = false;
        ngebatikGame.SetActive(false);

        playerLocomotion = player.GetComponentInChildren<BNG.SmoothLocomotion>();
        playerRotation = player.GetComponentInChildren<BNG.PlayerRotation>();


        gameInitialPosition = this.transform.position;

        full = new Color(1f, 1f, 1f, 1f);
        notFull = new Color(1f, 1f, 1f, 0.3f);

        rb1 = this.GetComponent<Rigidbody>();

        controllerTog.isOn = true;
        handTrackTog.isOn = false;
        reversedTog.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Kuis
        scoreTextComplete.text = score.ToString() + " / 5 Pertanyaan";
        scoreTextFail.text = score.ToString() + " / 5 Pertanyaan";
        if (kuisCompleted)
        {
            ngebatikButton.enabled = true;
        }

        // Ngebatik
        if (timerOn)
        {   
            if (countDown > 0f)
            {
                countDown -= Time.deltaTime;
                NgebatikTimer(countDown);
                if (!canting.GetComponent<BNG.Grabbable>().BeingHeld)
                {
                    ResetCantingPosition(false);
                }
            }
            else
            {
                countDown = 0;
                timerOn = false;
                SubmitButtonClicked();
            }
        }

        if (gameModePanel.activeSelf)
        {
            this.transform.position = gameInitialPosition;
        }
    }

    // Sinau Related
    public void SinauButton()
    {
        sinauPanel.SetActive(true);
        gameModePanel.SetActive(false);
    }

    public void CloseSinauButton()
    {
        sinauPanel.SetActive(false);
        gameModePanel.SetActive(true);
        kuisButton.enabled = true;
    }

    // Kuis Related
    public void KuisButton()
    {
        if(!kuisCompleted)
        {
            kuisPanel.SetActive(true);
            gameModePanel.SetActive(false);
            score = 0;
        }
    }

    public void BackKuisButton()
    {
        kuisPanel.SetActive(false);
        gameModePanel.SetActive(true);
    }

    public void CloseKuisButton()
    {
        kuisInfoPanel.SetActive(false);
        question1Panel.SetActive(true);
    }

    public void AddScoreKuis()
    {
        score++;
    }

    public void NextKuis1()
    {
        question1Panel.SetActive(false);
        question2Panel.SetActive(true);
    }

    public void NextKuis2()
    {
        question2Panel.SetActive(false);
        question3Panel.SetActive(true);
    }

    public void NextKuis3()
    {
        question3Panel.SetActive(false);
        question4Panel.SetActive(true);
    }

    public void NextKuis4()
    {
        question4Panel.SetActive(false);
        question5Panel.SetActive(true);
    }

    public void NextKuis5()
    {
        if (score >= 3)
        {
            question5Panel.SetActive(false);
            completeKuisPanel.SetActive(true);
        } else {
            question5Panel.SetActive(false);
            failKuisPanel.SetActive(true);
        }
    }

    public void ResultCloseKuisButton()
    {
        if (score >= 3)
        {
            kuisCompleted = true;
            completeKuisPanel.SetActive(false);
            gameModePanel.SetActive(true);
        } else {
            kuisCompleted = false;
            failKuisPanel.SetActive(false);
            gameModePanel.SetActive(true);
            kuisPanel.SetActive(false);
            question1Panel.SetActive(true);
        }
    }

    //Ngebatik Related
    public void NgebatikButton()
    {
        gameModePanel.SetActive(false);
        ngebatikPanel.SetActive(true);
    }

    public void NgebatikAturPosisiButton()
    {
        countDown = timeLeft;
        NgebatikTimer(countDown);
        rb1.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        rb1.isKinematic = false;
        ngebatikGame.GetComponent<BNG.Grabbable>().enabled = false;

        ngebatikGame.GetComponent<BNG.Grabbable>().enabled = true;

        submitButton.SetActive(false);
        readyButton.SetActive(true);
        ngebatikPanel.SetActive(false);
        ngebatikGame.SetActive(true);
        canting.gameObject.SetActive(false);
        cariCantingButton.SetActive(false);
    }

    public void ReadyNgebatikButton()
    {
        if (controllerTog.isOn)
        {
            readyButton.SetActive(false);
            submitButton.SetActive(true);
            pauseButtonGO.SetActive(true);
            cariCantingButton.SetActive(true);
            cantingInitialPosition = canting.transform.position;
            cantingInitialRotation = canting.transform.rotation;

            playerLocomotion.DisableMovement();
            playerRotation.AllowInput = false;
            countDown = timeLeft;
            timerOn = true;
            canting.gameObject.SetActive(true);
            canting.GetComponent<BNG.Grabbable>().enabled = true;

            rb1.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
            // rb1.detectCollisions = true;
            rb1.isKinematic = true;
            ngebatikGame.GetComponent<BNG.Grabbable>().enabled = false;
            // Destroy(this.GetComponent<Rigidbody>());
        }

        if (handTrackTog.isOn)
        {
            handVisualizer.SetActive(true);
            controllerLeft.SetActive(false);
            controllerRight.SetActive(false);
        }
    }

    public void CariCantingButton()
    {
        ResetCantingPosition(true);
    }

    public void SubmitButtonClicked()
    {
        timerOn = false;
        countDown = timeLeft;

        pauseButtonGO.SetActive(false);
        ngebatikGame.SetActive(false);
        hasilPanel.SetActive(true);

        ResetCantingPosition(true);

        // rb1 = this.gameObject.AddComponent<Rigidbody>();
        // rb1.mass = 1;
        // rb1.drag = 0;
        // rb1.angularDrag = 0.05f;
        // rb1.useGravity = false;
        // rb1.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        
        if (canting.GetComponent<BNG.Marker>().GetFinalScore() <= 30)
        {
            // bintang1.color = new Color(255, 255, 255, 255);
            // bintang2.color = new Color(255, 255, 255, 60);
            // bintang3.color = new Color(255, 255, 255, 60);

            bintang1.color = full;
            bintang2.color = notFull;
            bintang3.color = notFull;

            hasilDescription.text = "Kamu cukup hebat!";
        }
        else if (canting.GetComponent<BNG.Marker>().GetFinalScore() <= 60)
        {
            // bintang1.color = new Color(255, 255, 255, 255);
            // bintang2.color = new Color(255, 255, 255, 255);
            // bintang3.color = new Color(255, 255, 255, 60);
            bintang1.color = full;
            bintang2.color = full;
            bintang3.color = notFull;
            hasilDescription.text = "Kamu hebat!";
        }
        else if (canting.GetComponent<BNG.Marker>().GetFinalScore() <= 100)
        {
            // bintang1.color = new Color(255, 255, 255, 255);
            // bintang2.color = new Color(255, 255, 255, 255);
            // bintang3.color = new Color(255, 255, 255, 255);
            bintang1.color = full;
            bintang2.color = full;
            bintang3.color = full;
            hasilDescription.text = "Keren!";
        }
    }

    public void SubmitLanjutButton()
    {
        hasilPanel.SetActive(false);
        gameModePanel.SetActive(true);
        playerLocomotion.EnableMovement();
        playerRotation.AllowInput = true;
    }

    void NgebatikTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void TimerButtonClicked()
    {
        timerOn = false;
        pauseButtonGO.SetActive(false);
        ngebatikPause1.SetActive(true);
        // canting.gameObject.SetActive(false);
        canting.GetComponent<Rigidbody>().isKinematic = true;
        canting.GetComponent<BNG.Grabbable>().enabled = false;

        cariCantingButton.SetActive(false);
        submitButton.SetActive(false);
    }

    public void ResumeButtonClicked()
    {
        cariCantingButton.SetActive(true);
        submitButton.SetActive(true);
        canting.GetComponent<Rigidbody>().isKinematic = false;
        canting.GetComponent<BNG.Grabbable>().enabled = true;

        timerOn = true;
        ngebatikPause1.SetActive(false);
        canting.gameObject.SetActive(true);
        pauseButtonGO.SetActive(true);
    }

    public void QuitButtonClicked()
    {
        ngebatikPause1.SetActive(false);
        ngebatikPause2.SetActive(true);
    }

    public void QuitNoButtonClicked()
    {
        ngebatikPause2.SetActive(false);
        ngebatikPause1.SetActive(true);
    }

    public void QuitYesButtonClicked()
    {
        ngebatikPause2.SetActive(false);
        ngebatikGame.SetActive(false);
        gameModePanel.SetActive(true);
        playerLocomotion.EnableMovement();
        playerRotation.AllowInput = true;
    }

    private void ResetCantingPosition(bool boolean)
    {
        if (boolean)
        {
            canting.transform.position = cantingInitialPosition;
            canting.transform.rotation = cantingInitialRotation;
        }
        float timeThen;
        timeThen = Time.time;
        canting.GetComponent<Rigidbody>().isKinematic = true;
        if (Time.time == timeThen + 0.1f)
        {
            canting.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public Vector3 GetCantingInitialPosition()
    {
        return cantingInitialPosition;
    }

    public Quaternion GetCantingInitialRotation()
    {
        return cantingInitialRotation;
    }

    // Toko Related
    public void OnTokoClicked()
    {
        gameModePanel.SetActive(false);
        webViewPanel.SetActive(true);
        keyboard.SetActive(true);
        webViewClosePanel.SetActive(true);
    }

    public void OnCloseTokoClicked()
    {
        webViewPanel.SetActive(false);
        keyboard.SetActive(false);
        webViewClosePanel.SetActive(false);
        gameModePanel.SetActive(true);
    }
}
