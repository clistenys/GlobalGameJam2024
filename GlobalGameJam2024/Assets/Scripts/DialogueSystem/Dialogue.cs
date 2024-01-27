using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue")]
public class Dialogue : ScriptableObject
{
    public string title;
    public List<string> dialogue;
}
