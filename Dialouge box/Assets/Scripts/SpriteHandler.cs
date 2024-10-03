using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteHandler : MonoBehaviour
{
    public Sprite netrual, happy, angry, sad, shocked;
    public Image SR;

    public SpeechScript speech;
    void Start()
    {
        SR = GetComponent<Image>();
        SR.sprite = netrual;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(speech.counter == 2)
        {
            SR.sprite = happy;
        }
    }
}
