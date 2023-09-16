using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float Health;
    public float Concentration = 240f;
    public GameObject UI;
    public Slider UI_Concentration;
    public bool isFocus = false;
    public bool isSuperConcentrated = false;
    public float superConcentratedTime = 0.0f;
    public bool shutter = false;

    [SerializeField] GameObject Black;
    void Start()
    {
        Black.SetActive(false);
        UI_Concentration = UI.GetComponent<Slider>();    
        Application.targetFrameRate = 60;
    }

    public void SuperConcentrated()
    {
        if (isSuperConcentrated == true) 
        {
            Debug.Log("í¥èWíÜ");
            superConcentratedTime += Time.deltaTime;
            Debug.Log(superConcentratedTime);
            if (superConcentratedTime < 4f)
            {
                UI_Concentration.value -= 1f;
                Concentration -= 0.5f;
                Black.SetActive(true);
            }
            else
            {
                Black.SetActive(false);
                isSuperConcentrated = false;
                superConcentratedTime = 0.0f;
            }



        }
    }

    void Update()
    {
        SuperConcentrated();
    }
}
