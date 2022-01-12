using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    /* public float speed = 3.0f;
     public float maxZ = 16.0f;          //движение обьекта между этими точками
     public float minZ = -16.0f;

     private int _direction = 1;         // в каком направлении движется в данный момент

     void Update()
     {
         transform.Translate(0, 0, _direction * speed * Time.deltaTime);

         bool bounced = false;
         if(transform.position.z > maxZ || transform.position.z < minZ)
         {
             _direction = -_direction;        //меняем направление на противоположное

             bounced = true;
         }
         if (bounced)              //делаем дополнительное движение если обьект поменял направление
         {
             transform.Translate(0, 0, _direction * speed * Time.deltaTime);
         }
     }*/

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public const float baseSpeed = 3.0f;      //базовая скорость которая регулируется ползунком
    private bool _alive;

   // [SerializeField] private GameObject fireballPrefab;
    //private GameObject _fireball;



   /* private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }*/
    void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
               /* if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }*/
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
    private void OnSpeedChanged(float value)         //метод обьявленный в подписчике для события SPEED_CHANGED
    {
        speed = baseSpeed * value;
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
