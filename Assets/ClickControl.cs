using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickControl : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public Direction Direction_ = Direction.forward;
    public Rigidbody rb;
    public float speed = 200.2f;
    private bool bMove;
    public bool bCentPos;
    private Vector3 MovDir;
    public float dist;
    public bool onClickl;
    [HideInInspector]public Transform cross;

    public Vector3 iniPos;
    public Quaternion iniRot;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        iniPos = transform.position;
        iniRot = transform.rotation;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        if (bMove)
        {
           // Debug.Log("sas");
            rb.AddForce(MovDir * speed*Time.deltaTime, ForceMode.Impulse);
        }
        if(bCentPos)
        {
                dist = Vector3.Distance(transform.position, cross.position);
                rb.AddForce(-MovDir * speed * Time.deltaTime, ForceMode.Impulse);
            if (dist <.7f)
                {
                    bCentPos = false;
                    this.transform.position = cross.position;
                    Stop();
                    Turn();
                }
            
        }
    }
    public void Stop()
    {
        bMove = false;
        rb.velocity=Vector3.zero;
        Debug.Log(transform.name);
    }

    public enum Direction{
        forward, backward , left, right ,LUTurn ,RUTurn
    };

    public void Turn()
    {
        StartCoroutine(wait());
 
    }
    public void TurnLeft()
    {
        transform.Rotate(0, 0, -90);
        MovDir = -transform.up;
        bMove = true;
    }
    public void TurnRight()
    {
        transform.Rotate(0, 0, 90);
        MovDir = -transform.up;
        bMove = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickl = true;
        rb.constraints = ~RigidbodyConstraints.FreezeAll;
        if(Direction_ == Direction.forward)
        {
            MovDir = -transform.up;
            bMove = true;

        }
        else if(Direction_ == Direction.backward)
        {
            MovDir = -transform.up;
            bMove = true;
        }
        else if (Direction_ == Direction.left)
        {
            MovDir = -transform.up;
            bMove = true;
        }
        else if(Direction_ == Direction.right){
            MovDir = -transform.up;
            bMove = true;
        }
        else if(Direction_ == Direction.LUTurn)
        {
            MovDir = -transform.up;
            bMove = true;
        }
        else if (Direction_ == Direction.RUTurn)
        {
            MovDir = -transform.up;
            bMove = true;
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(.1f);
        if (Direction_ == Direction.left)
        {
            TurnLeft();
        }
        if (Direction_ == Direction.right)
        {
            TurnRight();
        }
        if (Direction_ == Direction.LUTurn)
        {
            TurnLeft();
        }
        if (Direction_ == Direction.RUTurn)
        {
            TurnRight();
        }
    }
}
