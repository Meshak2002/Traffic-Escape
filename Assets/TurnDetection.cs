using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private ClickControl cc;
    public bool once;
    private Vector3 originalPosition;
    private float shakeDuration = 0f;
    private float shakeIntensity = 0f;
    private Transform shakeT;
    private bool bShake;
    void Start()
    {
        cc = transform.parent.GetComponent<ClickControl>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Cross"))
        {
            Debug.Log("T");
            if (cc.Direction_ == ClickControl.Direction.LUTurn || cc.Direction_ == ClickControl.Direction.RUTurn)
            {
                Debug.Log("TOnce");
                once = false;
                /*cc.cross = other.transform;
                cc.bCentPos = true;
                once = true;*/
            }
        }

        if (once == false)
        {
            if (cc.Direction_ != ClickControl.Direction.forward)
            {
                if (other.CompareTag("Cross"))
                {
                    cc.cross = other.transform;
                    cc.bCentPos = true;
                    once = true;
                    Debug.Log("Once");
                }
            }
        }

  
        if (other.gameObject.CompareTag("Car"))
        {
            if (cc.onClickl)
            {
                Debug.Log(other.transform.position);
                cc.Stop();
                
                once = false;
                cc.onClickl = false;
                originalPosition= transform.parent.position;
                shakeT = transform.parent.transform;
                Shake(.2f,.3f);
                StartCoroutine(wai());
            }
        }
        if (other.CompareTag("Win"))
        {
            GameManager.instance.TCars.Add(this.transform.parent.transform);
        }
    }
    IEnumerator wai()
    {
        yield return new WaitForSeconds(.5f);
        transform.parent.position = cc.iniPos;
        transform.parent.rotation = cc.iniRot;
        cc.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Shake(float duration, float intensity)
    {
        bShake = true;
        shakeDuration = duration;
        shakeIntensity = intensity; // Store the original position before shaking
    }

    void Update()
    {
        if (bShake)
        {
            if (shakeDuration > 0)
            {
                // Generate a random offset within the intensity range
                Vector3 offset = Random.insideUnitSphere * shakeIntensity;

                // Apply the offset to the object's position
                shakeT.position = originalPosition + offset;

                // Decrease the remaining shake duration
                shakeDuration -= Time.deltaTime;
            }
            else
            {
                // Reset the position when the shake duration is over
                shakeDuration = 0f;
                //shakeT.position = originalPosition;
               
                bShake = false;
            }
        }
    }
}
