using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraft : MonoBehaviour
{
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        Item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ItemUp" && GameObject.Find("Scenary").GetComponent<ScenaryController>().DoorOpenComplete)
        {
            //Instantiate(Item, transform.position + new Vector3(0, 0, 0.5f), Quaternion.identity);

            StartCoroutine(Craft(collision));
        }
    }
    IEnumerator Craft(Collision collision)
    {
        Item.SetActive(true);
        GameObject.Find("ItemUp").SetActive(false);
        GameObject.Find("ItemDown").SetActive(false);
        yield return new WaitForSeconds(5);
        
        GameObject.Find("Scenary").GetComponent<ItemImageController>().CreateImage();
        
    }
}
