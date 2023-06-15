using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_Hand : MonoBehaviour
{

    public TextMeshProUGUI textController;

    public List<string> textList;
    public List<AnimationClip> animationList;
    public Animation handAni;
    [SerializeField] private GameObject button;

    private int currentIndex = 0;

    private void Start() {

        UpdateText();
        button.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            Debug.Log(currentIndex);

            //if(currentIndex >= textList.Count) {

            //    return;
            //}

            UpdateText();
            PlayAnimations();
        }

        if (currentIndex >= animationList.Count)
        {

            currentIndex = 0;
        }

        if (currentIndex >= textList.Count)
        {

            currentIndex = 0;
        }
    }
    private void UpdateText() { 
    
        if(textController != null) { 
        
            textController.text = textList[currentIndex];
        }
    }

    private void PlayAnimations() {

        currentIndex++;

        //if(animationList != null && animationList.Count <= currentIndex) { 
        
        //    currentIndex = 0;
        //}
            AnimationClip animation = animationList[currentIndex];
            handAni.Play(animation.name);

        if(currentIndex == 3) { 
        
            button.SetActive(true);
        }
    }



    //public void PlayNext() { 
    
    //    if(currentIndex < animationClips.Count) { 
            
            
    //        AnimationClip clip = animationClips[currentIndex];
    //        string texto = textList[currentIndex];
    //        mainText.text = texto;
    //        handAnimator.Play(clip.name);
    //        currentIndex++;
    //        handAnimator.SetFloat("aniList", +1);                        
    //    }
    //}

}