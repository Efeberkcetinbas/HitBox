using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerControl : MonoBehaviour
{
    private Vector3 firstPosition;
    private Vector3 lastPosition;

    private float dragDistance;

    public Animator animator;

    public PlayerData playerData;
    public CentralData centralData;

    private CentralControl centralControl;

    [SerializeField] private Transform rightGlove,leftGlove;


    private bool isLeft;



    [SerializeField] private Transform leftPunch,RightPunch;
    [SerializeField] private Transform up,down,left,right;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnResetUp,ResetUpDirection);
        EventManager.AddHandler(GameEvent.OnResetDown,ResetDownDirection);
        EventManager.AddHandler(GameEvent.OnResetLeft,ResetLeftDirection);
        EventManager.AddHandler(GameEvent.OnResetRight,ResetRightDirection);

        EventManager.AddHandler(GameEvent.OnTargetHit,OnTargetHit);    
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnResetUp,ResetUpDirection);
        EventManager.RemoveHandler(GameEvent.OnResetDown,ResetDownDirection);
        EventManager.RemoveHandler(GameEvent.OnResetLeft,ResetLeftDirection);
        EventManager.RemoveHandler(GameEvent.OnResetRight,ResetRightDirection);

        EventManager.RemoveHandler(GameEvent.OnTargetHit,OnTargetHit);
    }

    private void Start() 
    {
        centralControl=FindObjectOfType<CentralControl>();
        
    }

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
                        RightDirection();
                        //playerData.playerCanMove=false;
                        EventManager.Broadcast(GameEvent.OnPlayerRight);
                    }
                    else
                    {
                        LeftDirection();
                        //playerData.playerCanMove=false;
                        EventManager.Broadcast(GameEvent.OnPlayerLeft);
                        //animator.SetBool("Jump",true);
                    }
                }

                else
                {
                    if(lastPosition.y>firstPosition.y)
                    {
                        UpDirection();
                        //playerData.playerCanMove=false;
                        EventManager.Broadcast(GameEvent.OnPlayerUp);
                        //animator.SetBool("Jump",true);
                    }
                    
                    else if(lastPosition.x==firstPosition.x && lastPosition.y==firstPosition.y)
                    {
                        //playerData.playerCanMove=false;
                        //Center
                    }
                    else 
                    {
                        DownDirection();
                        //playerData.playerCanMove=false;
                        EventManager.Broadcast(GameEvent.OnPlayerDown);
                        //animator.SetBool("Jump",true);
                        // ?????????????? SORUN VARRRR
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

    #region DirectionsMove

    private void UpDirection()
    {
        DoPunch(up);
        centralData.playerUpHit=true;
    }
    private void DownDirection()
    {
        DoPunch(down);
        centralData.playerDownHit=true;
    }
    private void LeftDirection()
    {
        DoPunch(left);
        centralData.playerLeftHit=true;
    }
    private void RightDirection()
    {
        DoPunch(right);
        centralData.playerRightHit=true;
    }
   
    private void OnTargetHit()
    {
        if(isLeft) leftGlove.DOScale(new Vector3(0.6f,0.6f,0.6f),0.2f).OnComplete(()=>leftGlove.DOScale(new Vector3(0.4f,0.4f,0.4f),0.2f));
        else    rightGlove.DOScale(new Vector3(0.6f,0.6f,0.6f),0.2f).OnComplete(()=>rightGlove.DOScale(new Vector3(0.4f,0.4f,0.4f),0.2f));
    }
    private void DoPunch(Transform punch)
    {
        isLeft=!isLeft;

        if(isLeft)
        {
            leftGlove.DOLookAt(punch.transform.position,0.1f);
            leftPunch.DOMove(punch.transform.position,0.1f).OnComplete(()=>{
                leftPunch.DOLocalMove(new Vector3(-0.0610569f,0.0910638f,0.0075707f),0.1f);
            });
        }
        else
        {
            rightGlove.DOLookAt(punch.transform.position,0.1f);
            RightPunch.DOMove(punch.transform.position,0.1f).OnComplete(()=>{
                RightPunch.DOLocalMove(new Vector3(0.0610569f,0.0910638f,0.0075707f),0.1f);
            });
        }

    }

    private IEnumerator SetFalse(Animator animator,string Punch,bool closeLoop)
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool(Punch,closeLoop);
    }


    private void ResetUpDirection()
    {
        centralData.playerUpHit=false;
    }

    private void ResetDownDirection()
    {
        centralData.playerDownHit=false;
    }

    private void ResetLeftDirection()
    {
        centralData.playerLeftHit=false;
    }

    private void ResetRightDirection()
    {
        centralData.playerRightHit=false;
    }

    

    #endregion

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
    private void RotateYAxis(Transform punch, float y)
    {
        punch.DORotate(new Vector3(0,y,0),0.1f);
    }

    #endregion
}
