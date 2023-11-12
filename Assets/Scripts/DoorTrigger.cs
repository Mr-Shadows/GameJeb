using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public ScenaryController sc;
    public Transform NextPosition;
    public GameObject dragItem;
    public GameObject rotObj;
    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RoomCylinder") // ֿנמגונÿול, קעמ מבתוךע, גמרוהרטי ג ענטדדונ, טלווע עוד "Player"
        {
            Debug.Log("Ru entered the trigger zone");
            sc.RuchkaComplete = true;
            dragItem = other.gameObject;
            dragItem.GetComponent<Rigidbody>().useGravity = false;
            dragItem.GetComponent<Rigidbody>().freezeRotation = true;
            dragItem.GetComponent<Collider>().enabled = false;
            dragItem.transform.position = NextPosition.position;
            dragItem.transform.rotation = NextPosition.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            sc.DoorOpenComplete = true;
            
            dragItem.transform.position = NextPosition.position;
            dragItem.transform.rotation = NextPosition.rotation;
            rotObj.transform.rotation =Quaternion.Lerp(rotObj.transform.rotation,Quaternion.Euler(-90, -90, 0),Time.deltaTime * 2);
        }
        
    }
}
