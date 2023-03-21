using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    private Vector3 firstPosition;
    private Vector3 lastPosition;

    private float dragDistance;

    //public Animator animator;

    public PlayerData playerData;
    void Update()
    {
        CheckMove();

    }

    private void CheckMove()
    {

        if(Input.touchCount>0 && playerData.playerCanMove)
        {
            Touch touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                firstPosition=touch.position;
                lastPosition=touch.position;
            }

            else if(touch.phase==TouchPhase.Moved)
            {
                lastPosition=touch.position;
            }

            else if(touch.phase==TouchPhase.Ended)
            {
                lastPosition=touch.position;

                if(Mathf.Abs(lastPosition.x-firstPosition.x)>Mathf.Abs(lastPosition.y-firstPosition.y))
                {
                    if(lastPosition.x>firstPosition.x)
                    {
                        //animator.SetBool("Jump",true);
                        Debug.Log("Right");
                    }
                    else
                    {
                        Debug.Log("Left");
                        //animator.SetBool("Jump",true);
                    }
                }

                else
                {
                    if(lastPosition.y>firstPosition.y)
                    {
                        Debug.Log("Up");
                        //animator.SetBool("Jump",true);
                    }
                    else
                    {
                        Debug.Log("Down");
                        //animator.SetBool("Jump",true);

                    }
                }


            }
        }
    }

    private IEnumerator JumpToFalse()
    {
        //animator.SetBool("Jump",false);
        yield return new WaitForSeconds(.1f);
    }

    #region Move
    private void GoXAxis(float direction)
    {
        
    }

    private void GoZAxis(float direction)
    {
        
    }

    #endregion

    #region Jump
    private void JumpXAxis(float direction,float rot)
    {
        
    }

    private void JumpZAxis(float direction,float rot)
    {
        
    }
    #endregion

    #region  Rotate
    private void RotateYAxis(float y)
    {

    }

    #endregion
}
