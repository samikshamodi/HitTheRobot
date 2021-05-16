using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ArTapToPlaceObject : MonoBehaviour
{

    public GameObject gameObjectToInstantiate;
    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition; 
    public static int cnt=0;
   
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
     private void Awake()
     {
         _arRaycastManager=GetComponent<ARRaycastManager>();
     }

     bool TryGetTouchPosition(out Vector2 touchPosition)
     {
         if(Input.touchCount>0)
         {
             touchPosition=Input.GetTouch(0).position;
             return true;
         }
         touchPosition=default;
         return false;
     }

  /*   bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position=new Vector2(Inpn.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition,results);
        return results.Count>0;

    } */

    // Update is called once per frame

    void Update()
    {

        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;


            if(_arRaycastManager.Raycast(touchPosition,hits,TrackableType.PlaneWithinPolygon))
            {
                var hitPose=hits[0].pose;

                /* figure out if spawned object already. If already then move around else spawn */
                if(spawnedObject==null && cnt==1)
                {
                    /* then create it */
                    spawnedObject=Instantiate(gameObjectToInstantiate,hitPose.position,hitPose.rotation);
                    cnt=1;
                }
               /*   else{
                    spawnedObject.transform.position=hitPose.position;
                }  */
            }        

            
    }

    public void rescanButton()
    {
    
        spawnedObject=null;
        cnt=1;
    
    }

    
}
