using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NarrativePanel : MonoBehaviour
{

    public GameObject panel;
    [SerializeField] Image imagePanel;


    public void SetImage(Sprite image)
    {
        imagePanel.sprite = image;
    }

    public void ResetImage()
    {
        imagePanel.sprite = null;
    }

    public void StartPanel(Sprite image)
    {
        SetImage(image);
        panel.SetActive(true);
    }

    public void ResetPanel()
    {
        ResetImage();
        panel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
