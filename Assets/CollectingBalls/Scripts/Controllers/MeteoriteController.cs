using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 10, 1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.green);
            //Debug.Log("Косание зеленым");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, 10, 1))
        {
            if(hit.distance > 1.5f)
                _transform.position = new Vector3(_transform.position.x, 
                                                  hit.collider.transform.position.y + Random.Range(0.1f , 1.5f),
                                                  _transform.position.z);

            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
            //Debug.Log("Косание желтым");
        }

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10, 1))
        {
            if (hit.distance < 0.1f)
                _transform.position = new Vector3(_transform.position.x,
                                                  _transform.position.y,
                                                  _transform.position.z - 0.1f);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            //Debug.Log("Косание синим");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hit, 10, 1))
        {
            if (hit.distance < 0.1f)
                _transform.position = new Vector3(_transform.position.x,
                                                  _transform.position.y,
                                                  _transform.position.z + 0.1f);

            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * hit.distance, Color.cyan);
            //Debug.Log("Косание бирюзовым");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 10, 1))
        {
            if (hit.distance < 0.1f)
                _transform.position = new Vector3(_transform.position.x - 0.1f,
                                                  _transform.position.y,
                                                  _transform.position.z);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
            //Debug.Log("Косание красным");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out hit, 10, 1))
        {
            if (hit.distance < 0.1f)
                _transform.position = new Vector3(_transform.position.x + 0.1f,
                                                  _transform.position.y,
                                                  _transform.position.z);

            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * hit.distance, Color.magenta);
            //Debug.Log("Косание фиолетовым");
        }

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward)) &&
           Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward)) &&
           Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right)) &&
           Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right)))
        {
            _transform.position = new Vector3(_transform.position.x, _transform.position.y + 7, _transform.position.z);
            Debug.Log("Заспаунился в здании");
        }
    }
}
