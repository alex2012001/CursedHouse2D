using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogText;

    public Animator anim;

    private Queue<string> sentances;

    void Start()
    {
        sentances = new Queue<string>();
        
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
    }

    public void EndDialog()
    {
        Debug.Log("End");
        anim.SetBool("isOne", false);
    }

}
