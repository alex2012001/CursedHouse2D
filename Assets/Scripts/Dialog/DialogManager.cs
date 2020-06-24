using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogText;

    public Animator anim;
    public GameObject timer;
    public GameObject button;
    private int kek;

    private Queue<string> sentances;

    void Start()
    {
        sentances = new Queue<string>();
        kek = 0;
    }

    public void StartDialog(Dialog dialog)
    {
        anim.SetBool("isOne", true);

       

        Debug.Log("Talk to " + dialog.name);

        nameText.text = dialog.name;

        sentances.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentances.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
            button.SetActive(false);
        if(sentances.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentances.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
        button.SetActive(true);
 

    }

    public void EndDialog()
    {

        Debug.Log("End");
        kek++;
        anim.SetBool("isOne", false);
        if(kek == 2)
        {
            timer.SetActive(true);
        }
     
    }

}
