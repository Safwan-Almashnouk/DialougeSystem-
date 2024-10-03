using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using static Writer;
using Random = UnityEngine.Random;

public class SpeechScript : MonoBehaviour
{
    private Text messageText;
    public int counter, Hcounter, sCounter, Acounter,ConCounter = 0;
    public string[] messageArray;
    public GameObject textholder;
    private Writer.TextWriterSingle textWriterSingle;
    private bool Completed = false;
    public GameObject button;
    public GameObject ChoiceButtons;
    private bool happy, sad, angry, conufsed = false;
    public SpriteHandler sp;
    public string[] happyMesseges;
    public string[] sadMesseges;
    public string[] angryMesseges;
    public string[] conufsedMesseges;

    private void Start()
    {
        messageText = textholder.GetComponent<Text>();
        sp = GetComponentInParent<SpriteHandler>();
    }

    public void SkipText()
    {


        if (happy == true)
        {
           
            string happyMessege = happyMesseges[Hcounter];
            Hcounter++;
            textWriterSingle = Writer.AddWriter_Static(messageText, happyMessege, 0.2f, true, true);
        }
        if (sad == true) 
        {
            
            string sadMessege = sadMesseges[sCounter];
            sCounter++;
            textWriterSingle = Writer.AddWriter_Static(messageText, sadMessege, 0.2f, true, true);
        }
        if(angry == true)
        {
            
            string angryMessege = angryMesseges[Acounter];
            Acounter++;
            textWriterSingle = Writer.AddWriter_Static(messageText, angryMessege, 0.2f, true, true);
        }
        if (conufsed == true) 
        {
            string confusedmessage = conufsedMesseges[ConCounter];
            ConCounter++;
            textWriterSingle = Writer.AddWriter_Static(messageText, confusedmessage, 0.2f, true, true);
        }


        counter++;
        string message = messageArray[counter];
        textWriterSingle = Writer.AddWriter_Static(messageText, message, 0.2f, true, true);
    }


    public void Update()
    {
        if (counter >= messageArray.Length)
        {
            Completed = true;
            button.SetActive(false);
            ChoiceButtons.SetActive(true);
        }

        if (happy == true || angry == true || sad == true || conufsed == true) 
        { 
            ChoiceButtons.SetActive(false );
            button.SetActive(true);
        }

    }


    public void Happy()
    {
        sp.SR.sprite = sp.happy;
        happy = true;
        SkipText();
    }

    public void Sad()
    {
        sp.SR.sprite = sp.sad;
        sad = true;
        SkipText();
    }

    public void Angry()
    {
        sp.SR.sprite = sp.angry;
        angry = true;
        SkipText();

    }

    public void Confused()
    {
        sp.SR.sprite = sp.shocked;
        conufsed = true;
        SkipText();
    }
}



