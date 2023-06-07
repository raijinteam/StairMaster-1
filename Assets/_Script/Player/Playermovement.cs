using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public PlayerBody myBody;

   [SerializeField] private GameObject[] all_body;
   
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
    private bool isFilp = false;
    private bool isSetPostion = false;
    private Vector3 storePostion;
    

    private void Start() {
       
        isTopPostion = false;
       GameObject current =  Instantiate(all_body[DataManager.instance.PlayerIndex], 
           transform.position, transform.rotation);

        myBody = current.GetComponent<PlayerBody>();
        myBody.target = transform;
        GameManager.instance.isplayerLive = true;
      
    }

    public void Reset() {
        if (isTopPostion) {
            myBody.transform.localEulerAngles = new Vector3(0, 0, -180);
        }
        else {
            myBody.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }



    private void Update() {
        if (!GameManager.instance.isplayerLive) {
          //  myBody.animator.enabled = false;
            return;
           
        }

        if (!isTopPostion) {
            Jump();
        }
        else {

            JumpDownWord();
        }

       
       
        

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
            if (colliders.Length<=1) {
                transform.position = new Vector3(transform.position.x, postion.y, transform.position.z);
                storePostion = transform.position;
            }
            else {
                transform.position = storePostion;
            }
           
            velocity = 0;
            isGround = true;
            isJump = false;
            jumpCount = 0;
            isFilp = false;
            //  myBody.animator.SetTrigger(id_Running);
          



        }
        else {

            if (isJump) {
              //  myBody.animator.SetTrigger(id_Jump);
              
            }
            isGround = false;


        }

        //if (Input.GetMouseButtonDown(0) && isGround && Input.mousePosition.x > Screen.width / 2f) {
        //    velocity = MathF.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GravityScale));
        //    myBody.JumpRotation(isTopPostion);
        //    isJump = true;
        //    AudioManager.instance.PlayJumpSFX();
        //}
        //if (Input.GetMouseButtonDown(0) && !isFilp && Input.mousePosition.x < Screen.width / 2f) {
        //    AudioManager.instance.PlayPathChangeSFX();
        //    isFilp = true;
        //    MotionInput();
        //}

        if (Input.GetMouseButtonDown(0) && isGround) {
            velocity = MathF.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GravityScale));
            myBody.JumpRotation(isTopPostion);
            isJump = true;
            jumpCount += 1;
            AudioManager.instance.PlayPathChangeSFX();
        }
        else if (Input.GetMouseButtonDown(0) && jumpCount == 1) {
            jumpCount = 2;
            MotionInput();

        }




        transform.Translate(Vector3.up * velocity *Time.deltaTime);
       
    }

    private IEnumerator fixpopstion(Vector3 position) {
        yield return new WaitForSeconds(0.5f);
        transform.position = position;
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
            if (colliders.Length <= 1) {
                transform.position = new Vector3(transform.position.x, postion.y, transform.position.z);
                storePostion = transform.position;
            }
            else {
                transform.position = storePostion;
            }
            velocity = 0;
            isGround = true;
           // myBody.animator.SetTrigger(id_Running);
            isJump = false;
            isFilp = false;
            jumpCount = 0;
           

        }
        else {
            isGround = false;

            if (isJump) {
              //  myBody.animator.SetTrigger(id_Jump);

            }

        }

        //if (Input.GetMouseButtonDown(0) && isGround && Input.mousePosition.x > Screen.width / 2f) {
        //    velocity = MathF.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GravityScale));
        //    myBody.animator.SetTrigger(id_Jump);
        //    myBody.JumpRotation(isTopPostion);
        //    isJump = true;
        //    AudioManager.instance.PlayJumpSFX();
        //}

        //if (Input.GetMouseButtonDown(0) && !isFilp && Input.mousePosition.x < Screen.width / 2f) {
        //    AudioManager.instance.PlayPathChangeSFX();
        //    MotionInput();
        //    isFilp = true;
        //}

        if (Input.GetMouseButtonDown(0) && isGround) {
            velocity = MathF.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * GravityScale));
            //  myBody.animator.SetTrigger(id_Jump);
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

     
        StopAllCoroutines();    

        if (!isTopPostion) {

               
         
                velocity = 0;
                transform_Ground.localPosition = new Vector3(-1, -1, 0);
            
                transform.rotation = Quaternion.Euler(new Vector3(180, 0, 0));
              
                myBody.RotateBody(Quaternion.Euler(new Vector3(0, 0,180)), true);

                isTopPostion = true;
            }
        else {


             Quaternion target = Quaternion.Euler(new Vector3(0, 0, 360));
           
            transform_Ground.localPosition = new Vector3(1, -1, 0);
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            
            //StartCoroutine(MotionAnimation(Vector3.zero,target));

            myBody.RotateBody(target,false);
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