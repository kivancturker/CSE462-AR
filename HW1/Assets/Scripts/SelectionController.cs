using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectionController : MonoBehaviour
{
    public SelectableObject[] selectableObject;

    [SerializeField]
    private Color correctColor = Color.green;

    [SerializeField]
    private Color incorrectColor = Color.red;

    [SerializeField]
    private Camera arCamera;

    private Vector2 touchPosition = default;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {
                    SelectableObject hittedObject = hitObject.transform.GetComponent<SelectableObject>();
                    // One of the selectable objects hitted.
                    if (hittedObject != null)
                    {
                        Debug.Log(hittedObject.name);
                        /*if (hittedObject.GetComponent<GameObject>().name == "Sphere")
                        {
                            playButton.SetActive(false);
                        }*/
                        ChangeSelectedObject(hittedObject);
                        
                    }
                }
            }
        }
    }

    private void ChangeSelectedObject(SelectableObject selected)
    { 
        foreach (SelectableObject current in selectableObject)
        { 
            if (selected != current)
            {
                current.isSelected = false;
            }
            else
            {
                current.isSelected = true;
                if (current.name == "PlayButton3D")
                {
                    SceneManager.LoadScene("Game1");
                }
                else
                {
                    ChangeColor(current);
                    ChangeText(current);
                }
            }
        }
    }

    private void ChangeColor(SelectableObject selected)
    {
        MeshRenderer meshRenderer = selected.GetComponent<MeshRenderer>();
        if (selected.isCorrect)
        {
            meshRenderer.material.color = correctColor;
        }
        else
        {
            meshRenderer.material.color = incorrectColor;
        }
    }

    private void ChangeText(SelectableObject selected)
    {
        TextMeshPro question = GameObject.Find("Question").GetComponent<TextMeshPro>();
        if (selected.isCorrect)
        {
            question.text = "Correct";
        }
        else
        {
            question.text = "Incorrect";
        }
    }

}
