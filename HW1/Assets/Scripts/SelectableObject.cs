using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public bool isSelected { get; set; }

    public bool isCorrect;

    public string name;

    private void Awake()
    {
        name = gameObject.name;
    }
}
