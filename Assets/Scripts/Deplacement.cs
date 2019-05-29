using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {

    public int mCurrentIndex = 0;
    public Vector3[] Transforming;
    public float speed;
    public void Yes()
    {

        mCurrentIndex = Random.Range(1, 6);
        //var i = mCurrentIndex;
        Debug.Log("displacement?");
        //transform.Translate(Transforming[mCurrentIndex] * Time.deltaTime);
        Debug.Log("displacement");
         transform.LookAt(Transforming[mCurrentIndex]);
        


        StartCoroutine(Lancer());
    }

    public void Start()
    {
        Yes();
        
    }
    private void Update()
    {

        Vector3 currentPos = Transforming[mCurrentIndex];
        transform.position = Vector3.Lerp(transform.position, currentPos, speed * Time.deltaTime);
    }
    IEnumerator Lancer()
    {
        yield return new WaitForSeconds(5f);
        Yes();
    }






}
