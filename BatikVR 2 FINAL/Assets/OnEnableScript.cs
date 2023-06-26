using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableScript : MonoBehaviour
{
    private void OnEnable() {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
