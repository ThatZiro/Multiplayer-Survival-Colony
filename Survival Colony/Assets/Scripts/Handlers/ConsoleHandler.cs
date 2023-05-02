using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleHandler : MonoBehaviour
{
    bool showConsole;
    bool showHelp;
    string input;
    Vector2 scroll;
    //Commands
    public List<object> commandList;

    public static DebugCommand SPECTATOR;
    public static DebugCommand<int> SET_SPEED;
    public static DebugCommand HELP;

    public void OnToggleDebug()
    {
        showConsole = !showConsole;
    }

    public void SendCommand()
    {
        if (showConsole)
        {
            string[] properties = input.Split(' ');

            for (int i = 0; i < commandList.Count; i++)
            {

                DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

                if (input.Contains(commandBase.commandID))
                {
                    if (commandList[i] as DebugCommand != null)
                    {
                        (commandList[i] as DebugCommand).Invoke();
                    }
                    else if (commandList[i] as DebugCommand<int> != null)
                    {
                        (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                    }

                }
            }

            input = "";
        }
    }
    private void OnGUI()
    {
        if(!showConsole) 
            {
            showHelp = false;
            input = "";
            return; }

        float y = 0f;


        if (showHelp)
        {
            GUI.Box(new Rect(0, y, Screen.width, 100), "");

            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);
            scroll = GUI.BeginScrollView(new Rect(0, y + 5, Screen.width, 90), scroll, viewport);

            for(int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommandBase;

                string label = $"{command.commandFormat} - {command.commandDescription}";

                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);
                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();

            y += 100;
        }
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        GUI.SetNextControlName("Console");
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
        GUI.FocusControl("Console");
    }

    private void Awake()
    {
        SPECTATOR = new DebugCommand("spectator", "toggles spectator move", "spectator", () =>
        {
            InputHandler ih = FindObjectOfType<InputHandler>();
            ih.isSpectator = !ih.isSpectator;
            if (ih.isSpectator)
            {
                ih.spectatorCamera.EnterSpectator();
            }
            else
            {
                ih.spectatorCamera.LeaveSpectator();
            }
            showConsole = false;
        });

        SET_SPEED = new DebugCommand<int>("set_speed", "Sets speed to value", "set_speed <amount>",  (x) => {
            Debug.Log("Speed has been set to " + x);
        });

        HELP = new DebugCommand("help", "Shows a list of commands", "help", () => {
            showHelp = true;
        });
        commandList = new List<object>
        {
            SPECTATOR,
            SET_SPEED,
            HELP
        };
    }
}
