using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour


{
    //public GameObject IconSelection;
    public TMP_Text dialogueText; //refrence to display actual text
    private Queue<string> sentences; //FIFO (First in first out data structure) private might need to be changed to public later to use it on other levels (if that's how that works lmao)

    //Initalization
    void Start()
    {

        sentences = new Queue<string>(); //Initalizes Queue
        //IconSelection.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue) //Begins Dialogue 
    {
        Debug.Log("Starting conversation" + dialogue.name); //Debug for testing 



        sentences.Clear(); //Clears Sentences so new one can load 

        foreach (string sentence in dialogue.sentences) //runs through the queue 
        {
            sentences.Enqueue(sentence); //Loads new Dialogue 
        }

        DisplayNextSentence();// After new Dialogue is loded, it displays the next sentence
    }
    public void DisplayNextSentence() //Next Sentence 
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log("Ending Conversation");
        dialogueText.text = sentence;


        void EndDialogue() //Signifies the end of the Dialogue 
        {
            Debug.Log("End of Conversation");
            ScenesManager.instance.LoadNextScene();


        }





    }

    public void displayNPCSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log("Ending Conversation");
        dialogueText.text = sentence;


        void EndDialogue() //Signifies the end of the Dialogue 
        {
            Debug.Log("End of Conversation");
            ScenesManager.instance.loadDungeon();


        }
    }
}
