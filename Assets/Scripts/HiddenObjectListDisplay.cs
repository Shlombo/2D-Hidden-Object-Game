using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjectListDisplay : MonoBehaviour
{

    public GUIStyle labelStyle;
    
    // Start is called before the first frame update
    void Start()
    {
        labelStyle = new GUIStyle(GUI.skin.label);
        labelStyle.fontSize = 20;
        labelStyle.normal.textColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        // Display the list of GameObjects on the screen
        GUILayout.BeginVertical();
        GUILayout.Label("List of Hidden Objects:", labelStyle);

        foreach (GameObject n in HiddenManager.Instance.hiddenObjects)
        {
            GUILayout.Label(n.name, labelStyle);
        }

        GUILayout.EndVertical();
    }
}
