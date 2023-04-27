using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public PlayerBody myBody;

   // [SerializeField] private GameObject body;
   
    [SerializeField]private bool isTopPostion;
    [SerializeField] private  float jumpHeight;
    [SerializeField] private  float GravityScale ;
    [SerializeField] private  float jumpScale ;
    private float heigthforDownToCenter = 0.38f;
    [SerializeField] private Transform transform_Ground;
    [SerializeField] private LayerMask ground;
    [SerializeField]private float velocity;
    private Collider2D[] colliders;
   
    [SerializeField] private float flt_TopAngle;
    [SerializeField] private float flt_DownAngle;
    
    private bool isJump;
    private int jumpCount = 0;
    private string id_Jump = "IsJump";
    private string id_Running = "IsRunning";
    

    private void Start() {
       
        isTopPostion = false;
       GameObject current =  Instantiate(myBody.gameObject, transform.position, transform.rotation);
        myBody = current.GetComponent<PlayerBody>();
        myBody.target = transform;
      
    }



    private void Update() {
        if (!GameManager.instance.isplayerLive) {
            myBody.animator.enabled = false;
            return;
           
        }

        if (!isTopPostion) {
            Jump();
        }
        else {

            JumpDownWord();
        }
      
        //MotionInput();
        

    }

    private void Jump() {
        bool isGround;

        if (!isJump) {
            velocity += Physics2D.gravity.y * GravityScale * Time.deltaTime;

        }
        else {
            velocity += Physics2D.gravity.y * jumpScale * Time.deltaTime;
        }

        colliders = Physics2D.OverlapBoxAll(transform_Ground.position, transform_Ground.localScale
            , 0, ground);

        if (colliders.Length > 0 && velocity < 0) {

            Vector2 postion = Physics2D.ClosestPoint(transform.position, colliders[0]) +
                Vector2.up * heigthforDownToCenter;
            transform.position = new Vector3(transform.position.x, postion.y, transform.position.z);
            velocity = 0;
            isGround = true;
            isJump = false;
            jumpCount = 0;
            myBody.animator.SetTrigger(id_Running);
           
            

        }
        else {

            if (isJump) {
                myBody.animator.SetTrigger(id_Jump);
              
            }
            isGround = false;


        }

        //if (Input.GetMouseButtonDown(0) && isGround && Input.mousePosition.x < Screen.width / 2f) {
        //    velocity = MathF.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GravityScale));
        //    myBody.JumpRotation(isTopPostion);
        //    isJump = true;
        //}

        if (Input.GetMouseButtonDown(0) && isGround) {
            velocity = MathF.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GravityScale));
            myBody.JumpRotation(isTopPostion);
            isJump = true;
            jumpCount += 1;
        }
        else if (Input.GetMouseButtonDown(0) && jumpCount == 1) {
            jumpCount = 2;
            MotionInput();
            
        }

        transform.Translate(Vector3.up * velocity *Time.deltaTime);
       
    }
    private void JumpDownWord() {

        bool isGround = true;
        if (!isJump) {
            velocity -= -Physics2D.gravity.y * GravityScale * Time.deltaTime;
        }
        else {
            velocity -= -Physics2D.gravity.y * jumpScale * Time.deltaTime;
        }
     
        colliders = Physics2D.OverlapBoxAll(transform_Ground.position, transform_Ground.localScale
           , 0, ground);

        if (colliders.Length > 0 && velocity < 0) {

            Vector2 postion = Physics2D.ClosestPoint(transform.position, colliders[0]) +
                Vector2.down * heigthforDownToCenter;
            transform.position = new Vector3(transform.position.x, postion.y, transform.position.z);
            velocity = 0;
            isGround = true;
            myBody.animator.SetTrigger(id_Running);
            isJump = false;
            jumpCount = 0;
        }
        else {
            isGround = false;

            if (isJump) {
                myBody.animator.SetTrigger(id_Jump);

            }

        }

        //if (Input.GetMouseButtonDown(0) && isGround && Input.mousePosition.x < Screen.width / 2f) {
        //    velocity = MathF.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GravityScale));
        //    myBody.animator.SetTrigger(id_Jump);
        //    myBody.JumpRotation(isTopPostion);
        //    isJump = true;
        //}

        if (Input.GetMouseButtonDown(0) && isGround) {
            velocity = MathF.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GravityScale));
            myBody.animator.SetTrigger(id_Jump);
            myBody.JumpRotation(isTopPostion);
            isJump = true;
            jumpCount += 1;
        }
        else if (Input.GetMouseButtonDown(0) && jumpCount == 1) {
            jumpCount += 1;
            MotionInput();
          
        }



        transform.Translate(Vector3.up * velocity * Time.deltaTime);

    }


    private void MotionInput() {

      

        //if (Input.GetMouseButtonDown(0)  && Input.mousePosition.x > Screen.width / 2f) {


        StopAllCoroutines();    



        if (!isTopPostion) {

                Quaternion target = Quaternion.Euler(new Vector3(180, 0, 0));
             
                velocity = 0;
                transform_Ground.localPosition = new Vector3(-1, -1, 0);
                transform.rotation = target;
              
                myBody.RotateBody(target);

                isTopPostion = true;
            }
        else {


             Quaternion target = Quaternion.Euler(new Vector3(0, 0, 0));
                transform_Ground.localPosition = new Vector3(1, -1, 0);
                transform.rotation = target;
              

                //StartCoroutine(MotionAnimation(Vector3.zero,target));

                myBody.RotateBody(target);
                velocity = 0;
                isTopPostion = false;
              
            }

        // }
    }

    //private IEnumerator MotionAnimation(Vector3 tartgetPostion ,Quaternion targetRotation) {
    //  float flt_CurrentTime = 0;
    //    Quaternion StartRotation = transform.rotation;
    //    Vector3 startPostion = transform.position;
    //    velocity = 0;

    //    Debug.Log("pos 3: " + transform.position);

    //    while (flt_CurrentTime < 1) {

           
    //            flt_CurrentTime += Time.deltaTime / motionTime;
    //      //  transform.position = Vector3.Lerp(startPostion, tartgetPostion, flt_CurrentTime);
    //        transform.rotation = Quaternion.Lerp(StartRotation, targetRotation, flt_CurrentTime);
      
    //        yield return null;
    //    }

    //   // transform.position = tartgetPostion;
    //    transform.rotation = targetRotation;

    //    if (isTopPostion) {
    //        isTopPostion = false;
    //    }
    //    else {
    //        isTopPostion = true;
    //    }


    //}


    private void OnDrawGizmos() {
        Gizmos.DrawCube(transform_Ground.position, transform_Ground.localScale);
          
    }




}