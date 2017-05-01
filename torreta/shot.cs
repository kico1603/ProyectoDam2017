using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
    public Transform disparador;
    public Rigidbody bala;
    public GameObject enemy;
    public float cadencia;
    private float cadenciapri;





    private void Start()
    {
        enemy = closestObject("enemy");
        
    }
    
    
    // Update is called once per frame
    void Update () {
        //if (Input.GetKeyDown(KeyCode.Q)) {

        
        cadenciapri += Time.deltaTime;

        
            
        if (enemy == null)
        {
            enemy = closestObject("enemy");
            
        }
        else {

            if (cadenciapri >= cadencia)
            {
                


                Rigidbody clone;
            clone = Instantiate(bala, disparador.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
                cadenciapri = 0;
            }
            Vector3 relativePos = enemy.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);


        }


        //Debug.Log(Time.deltaTime);

        //}
    }

    //Busca el objeto mas cercano con un tag
     GameObject closestObject(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = null;

        if (gameObjects.Length > 0)
        {
            closestObject = gameObjects[0];
            foreach (GameObject obj in gameObjects)
            {
                float distanceToObj = Vector3.Distance(transform.position, obj.transform.position);
                float distanceToClosestObject = Vector3.Distance(transform.position, closestObject.transform.position);
                if (distanceToObj < distanceToClosestObject)
                    closestObject = obj;
            }
        }
        else
        {
            return null;
        }
        return closestObject;
    }
}
