using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private Camera Camera;   
    [SerializeField] private Vector3 offset;
   public bool demoCamera=true;
 
    private void Start()
    {
        Camera.transform.position = new Vector3(0, 2.25f, 198f);
        Camera.transform.DOMove(new Vector3(0, 3f, 89f), 5f);

    }
    void Update()
    {
        if (!demoCamera)
            Camera.transform.position = offset + transform.position;
        StartCoroutine(StartCam());
       
    }
    private IEnumerator StartCam()
    {     
        yield return new WaitForSeconds(6f);
       
        demoCamera =false;
    }
}
