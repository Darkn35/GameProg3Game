using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitListIndex : MonoBehaviour
{
    [SerializeField] public List<ObjectBehavior> fruit = new List<ObjectBehavior>();
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int listIndex()
    {
        index = fruit.FindIndex(x => x == gameObject.GetComponent<ObjectBehavior>());

        return index;
    }

    public int listIndex(Collision2D collision)
    {
        index = fruit.FindIndex(x => x == collision.gameObject.GetComponent<ObjectBehavior>());

        return index;
    }
    public int listIndexTrig(Collider2D collision)
    {
        index = fruit.FindIndex(x => x == collision.gameObject.GetComponent<ObjectBehavior>());
       
        return index;
    }
}
