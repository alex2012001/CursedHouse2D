using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerTwo : MonoBehaviour
{
    private bool check;
    public Dialog dialog;
    public CrystalsCounter cr;
   
    private void Start()
    {
        check = false;
    }
    private void Update()
    {
        if(cr.countForTrigger == 2 && check == false)
        {
            TriggerDialog();
            check = true;
           
        }
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
