using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraft : MonoBehaviour
{
    public GameObject Item;
    float timer = 0;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        Item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            flag = false;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ItemUp" && GameObject.Find("Scenary").GetComponent<ScenaryController>().DoorOpenComplete)
        {
            //Instantiate(Item, transform.position + new Vector3(0, 0, 0.5f), Quaternion.identity);
            GameObject.Find("Scenary").GetComponent<ScenaryController>().ImageCreating = true;
            StartCoroutine(Craft(collision));
        }
    }
    IEnumerator Craft(Collision collision)
    {
        yield return new WaitForSeconds(5);
        Item.SetActive(true);
        GameObject.Find("ItemUp").SetActive(false);
        GameObject.Find("ItemDown").SetActive(false);


        GameObject.Find("Scenary").GetComponent<ItemImageController>().CreateImageFlag = true;



    }
}
