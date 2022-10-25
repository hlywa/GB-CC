using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("Narrrative",
             "Clear Menu",
             "Clears the options from a menu dialog")]
public class ClearMenu : Command
{
    public MenuDialog menuDialog;

    public override void OnEnter()
    {
        menuDialog.Clear();

        Continue();
    }

}
