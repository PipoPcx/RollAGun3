using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_Font : MonoBehaviour
{
    [SerializeField] private Button buton;
    [SerializeField] private Vector3 newScale = new Vector3 (1.1f, 1.1f, 1.1f);
    [SerializeField] private Vector3 originalScale;
    [SerializeField] private Animator animator;


    private void Start() {
        
        originalScale = buton.transform.localScale;
    }

    public void OnMouseEnter()
    {
        
        buton.transform.localScale = newScale;
        Debug.Log("a");
    }
    public void OnPointerEnter() {
       
        buton.transform.localScale = newScale;
        Debug.Log("a");
    }


    private void Update()
    {
        //if(Input.GetMouseButtonDown(0)) { animator.SetTrigger("activated"); }

    }

}
