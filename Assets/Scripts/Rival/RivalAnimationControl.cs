using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalAnimationControl : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private List<string> listOfFalseAnimations;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnRivalHitRight,OnRivalHitRight);
        EventManager.AddHandler(GameEvent.OnRivalHitLeft,OnRivalHitLeft);
        EventManager.AddHandler(GameEvent.OnRivalHitUp,OnRivalHitUp);
        EventManager.AddHandler(GameEvent.OnRivalHitDown,OnRivalHitDown);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnRivalHitRight,OnRivalHitRight);
        EventManager.RemoveHandler(GameEvent.OnRivalHitLeft,OnRivalHitLeft);
        EventManager.RemoveHandler(GameEvent.OnRivalHitUp,OnRivalHitUp);
        EventManager.RemoveHandler(GameEvent.OnRivalHitDown,OnRivalHitDown);
    }

   

    void OnRivalHitLeft()
    {
        listOfFalseAnimations.Clear();
        SetAnimationBool(animator,"isLeft");
    }

    void OnRivalHitRight()
    {
        listOfFalseAnimations.Clear();
        SetAnimationBool(animator,"isRight");
    }

    void OnRivalHitDown()
    {
        listOfFalseAnimations.Clear();
        SetAnimationBool(animator,"isDown");
    }

    void OnRivalHitUp()
    {
        listOfFalseAnimations.Clear();
        SetAnimationBool(animator,"isUp");
    }

    private void SetAnimationBool(Animator animator,string trueAnimationName)
    {

        listOfFalseAnimations.Add("isUp");
        listOfFalseAnimations.Add("isDown");
        listOfFalseAnimations.Add("isRight");
        listOfFalseAnimations.Add("isLeft");

        for (int i = 0; i < listOfFalseAnimations.Count; i++)
        {
            animator.SetBool(listOfFalseAnimations[i],false);
        }
        animator.SetBool(trueAnimationName,true);

        StartCoroutine(BackIdle(trueAnimationName));

    }

    private IEnumerator BackIdle(string _trueAnimationName)
    {
        yield return new WaitForEndOfFrame();
        animator.SetBool(_trueAnimationName,false);
        animator.SetBool("isIdle",true);

    }
}
