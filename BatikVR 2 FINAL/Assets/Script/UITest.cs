using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    public GameObject XROrigin;
    public GameObject panel;
    public GameObject canting;
    public GameObject ngebatikGame;

    [Header("UI Component")]
    public GameObject tutorialPanel;
    public GameObject tutorialArea;
    public GameObject backPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == XROrigin) {
            panel.gameObject.SetActive(true);
            tutorialArea.SetActive(false);
            tutorialPanel.SetActive(false);
            backPanel.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == XROrigin) {
            panel.gameObject.SetActive(false);
            canting.gameObject.transform.SetPositionAndRotation(new Vector3(0.341733634f,0.0939999968f,0.174999997f), new Quaternion(0f,0f,19.9999981f, 0f));
            tutorialArea.SetActive(true);
        }
    }
}
