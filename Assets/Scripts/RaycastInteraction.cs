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
        if(sc.RuchkaComplete)
        {
            drag = false;
            dragItem = null;
        }
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // Создаем луч, идущий из центра камеры в направлении, куда смотрит камера
        RaycastHit hit; // Информация о попадании луча
        if (drag)
        {
            DragPos = Camera.main.transform.position + Camera.main.transform.forward * 2f;
            dragItem.transform.position = Vector3.Lerp(dragItem.transform.position, DragPos, Time.deltaTime * 10);
        }
        if (drag == true && Input.GetMouseButtonUp(0))
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
                        texT.text = "Опять не понимаешь?. Там же написано. ВВЕДИ код";
                    }
                    else
                        texT.text = " ";
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

            if (hit.collider.tag == "Props" && Input.GetMouseButtonDown(0) && sc.LockComplete && !sc.RuchkaComplete)
            {
                dragItem = hit.collider.gameObject;
                hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                drag = true;
            }


            /*if(hit.collider.GetComponent<LockControl>())
            {
                texT.text = "Ну наконец-то, поздравляю, ты начал думмать";
                sc.LockComplete = true;
            }*/

        }
    }

}
