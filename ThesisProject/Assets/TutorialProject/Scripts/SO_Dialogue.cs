using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu
    (fileName = "New_Dialogue", menuName = "Dialogue")]

public class SO_Dialogue : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        [TextArea(4, 8)] 
            public string dialogue;

        
    }
    public Info[] dialogueInfo;

    
}
