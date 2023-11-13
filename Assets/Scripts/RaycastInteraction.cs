using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RaycastInteraction : MonoBehaviour
{
    public bool LockScenary = false;
    public TMP_Text texT;
    public float raycastDistance = 2f;
    public float timer;
    public GameObject dragItem;
    public bool drag = false;
    public Vector3 DragPos;
    public ScenaryController sc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // Создаем луч, идущий из центра камеры в направлении, куда смотрит камера
        RaycastHit hit; // Информация о попадании луча
        if (drag && (!sc.RuchkaComplete || sc.DoorOpenComplete))
        {
            DragPos = Camera.main.transform.position + Camera.main.transform.forward * 2f;
            dragItem.transform.position = Vector3.Lerp(dragItem.transform.position, DragPos, Time.deltaTime * 10);
        }
        if (drag && Input.GetMouseButtonUp(0) && (!sc.RuchkaComplete || sc.DoorOpenComplete))
        {
            drag = false;
            dragItem.GetComponent<Rigidbody>().useGravity = true;

            dragItem = null;
        }
        if (Physics.Raycast(ray, out hit, raycastDistance)) // Проверяем, столкнулся ли луч с каким-либо объектом на расстоянии до raycastDistance
        {
            if (hit.collider != null)
            {
                // Добавьте здесь логику для обработки попадания луча в объект
                if (hit.collider.tag == "Lock" && !sc.LockComplete)
                {
                    timer += Time.deltaTime;
                    Debug.Log(hit.collider.GetComponent<LockControl>());
                    LockScenary = true;
                    if (Input.GetKeyDown(KeyCode.Alpha0))
                    {
                        hit.collider.GetComponent<LockControl>().pass += '0';
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        hit.collider.GetComponent<LockControl>().pass += '1';
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        hit.collider.GetComponent<LockControl>().pass += "2";
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        hit.collider.GetComponent<LockControl>().pass += "3";
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        hit.collider.GetComponent<LockControl>().pass += "4";
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha5))
                    {
                        hit.collider.GetComponent<LockControl>().pass += "5";
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha6))
                    {
                        hit.collider.GetComponent<LockControl>().pass += "6";
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha7))
                    {
                        hit.collider.GetComponent<LockControl>().pass += "7";
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha8))
                    {
                        hit.collider.GetComponent<LockControl>().pass += "8";
                    }
                    if (Input.GetKeyDown(KeyCode.Alpha9))
                    {
                        hit.collider.GetComponent<LockControl>().pass += "9";
                    }
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        hit.collider.GetComponent<LockControl>().pass = "";
                    }

                    if (timer > 30 && timer < 35 && hit.collider.GetComponent<LockControl>().pass == "")
                    {
                        texT.text = "Не, ты не понял. ВВЕДИ код";
                    }

                }
            }
            if (hit.collider.GetComponent<TumbBoxController>() && Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<TumbBoxController>().open = !hit.collider.GetComponent<TumbBoxController>().open;
            }

            if (hit.collider.GetComponent<RadioScript>() && Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<RadioScript>().NextTrack();
            }

            if (hit.collider.GetComponent<GuitarScript>() && Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<GuitarScript>().PlayTrack();
            }

            if (hit.collider.name == "RoomHeandel" && sc.LockComplete && !sc.RuchkaComplete && Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<Rigidbody>().useGravity = true;

                sc.RuchkaSearchBegin = true;

            }
            if (hit.collider.gameObject.name == "Door" && sc.LockComplete && sc.RuchkaComplete && Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<DoorTrigger>().open = true;
            }
            if (hit.collider.tag == "Props" && Input.GetMouseButtonDown(0) && (!sc.RuchkaComplete || sc.DoorOpenComplete))
            {
                dragItem = hit.collider.gameObject;
                dragItem.transform.parent = null;
                hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                drag = true;
            }

            if (hit.collider.tag == "Wall" && Input.GetMouseButtonDown(0) && sc.ImageCreateComplete)
            {
                sc.WallDestroyChek = true;
            }
            if (hit.collider.tag == "Wall" && Input.GetKeyDown(KeyCode.Delete) && sc.ImageCreateComplete)
            {
                hit.collider.gameObject.GetComponent<WallControl>().WebcamRun = true;
            }
            //if(hit.collider.GetComponent<LockControl>().)
            //{

            //    sc.LockComplete = true;
            //}

        }
    }
    IEnumerator WritingSingleText(float sleepTime, string currentText)
    {
        yield return new WaitForSeconds(sleepTime);
        texT.text = currentText;
        //if (currentText != "")
        //{
        //    yield return new WaitForSeconds(sleepTime);
        //    text.text = "";
        //}
    }

}
