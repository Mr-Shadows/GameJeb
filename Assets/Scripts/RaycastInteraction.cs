using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public bool LockScenary = false;
    public float raycastDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // Создаем луч, идущий из центра камеры в направлении, куда смотрит камера
        RaycastHit hit; // Информация о попадании луча

        if (Physics.Raycast(ray, out hit, raycastDistance)) // Проверяем, столкнулся ли луч с каким-либо объектом на расстоянии до raycastDistance
        {
            // Добавьте здесь логику для обработки попадания луча в объект
            if(hit.collider.tag == "Lock")
            {
                LockScenary = true;
            }

        }
    }
}
