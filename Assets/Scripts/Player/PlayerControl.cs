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
    public CentralData centralData;

    private CentralControl centralControl;




    [SerializeField] private Transform leftPunch,RightPunch;
    [SerializeField] private Transform up,down,left,right,central;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnResetUp,ResetUpDirection);
        EventManager.AddHandler(GameEvent.OnResetDown,ResetDownDirection);
        EventManager.AddHandler(GameEvent.OnResetLeft,ResetLeftDirection);
        EventManager.AddHandler(GameEvent.OnResetRight,ResetRightDirection);
        EventManager.AddHandler(GameEvent.OnResetCenter,ResetCenterDirection);    
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnResetUp,ResetUpDirection);
        EventManager.RemoveHandler(GameEvent.OnResetDown,ResetDownDirection);
        EventManager.RemoveHandler(GameEvent.OnResetLeft,ResetLeftDirection);
        EventManager.RemoveHandler(GameEvent.OnResetRight,ResetRightDirection);
        EventManager.RemoveHandler(GameEvent.OnResetCenter,ResetCenterDirection);    
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
                        CentralDirection();
                        //playerData.playerCanMove=false;
                        EventManager.Broadcast(GameEvent.OnPlayerCenter);
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
        leftPunch.DOLocalMove(up.transform.position,0.1f).OnComplete(()=>leftPunch.DOLocalMove(new Vector3(-0.85f,-0.39f,-7.5f),0.1f));
        centralData.playerUpHit=true;
        centralData.byHitUp=true;
        centralControl.StopCoroutine(centralControl.CheckIfUpHitByPunch());
    }
    private void DownDirection()
    {
        RightPunch.DOLocalMove(down.transform.position,0.1f).OnComplete(()=>RightPunch.DOLocalMove(new Vector3(0.85f,-0.39f,-7.5f),0.1f));
        centralData.playerDownHit=true;
        centralData.byHitDown=true;
        centralControl.StopCoroutine(centralControl.CheckIfDownHitByPunch());
    }
    private void LeftDirection()
    {
        leftPunch.DOLocalMove(left.transform.position,0.1f).OnComplete(()=>leftPunch.DOLocalMove(new Vector3(-0.85f,-0.39f,-7.5f),0.1f));
        centralData.playerLeftHit=true;
        centralData.byHitLeft=true;
        centralControl.StopCoroutine(centralControl.CheckIfLeftHitByPunch());
    }
    private void RightDirection()
    {
        RightPunch.DOLocalMove(right.transform.position,0.1f).OnComplete(()=>RightPunch.DOLocalMove(new Vector3(0.85f,-0.39f,-7.5f),0.1f));
        centralData.playerRightHit=true;
        centralData.byHitRight=true;
        centralControl.StopCoroutine(centralControl.CheckIfRightHitByPunch());
    }
    private void CentralDirection()
    {
        RightPunch.DOLocalMove(central.transform.position,0.1f).OnComplete(()=>RightPunch.DOLocalMove(new Vector3(0.85f,-0.39f,-7.5f),0.1f));
        centralData.playerCentralHit=true;
        centralData.byHitCenter=true;
        centralControl.StopCoroutine(centralControl.CheckIfCenterHitByPunch());
    }

    /*private void RestartDirection()
    {
        centralData.playerUpHit=false;
        centralData.playerDownHit=false;
        centralData.playerLeftHit=false;
        centralData.playerRightHit=false;
        centralData.playerCentralHit=false;
    }*/

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

    private void ResetCenterDirection()
    {
        centralData.playerCentralHit=false;
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
