using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptShip : MonoBehaviour
{
    public float speed;

    public SpriteRenderer rend;

    public Transform other;

    public Color ColorA;
    public Color ColorD;

    public float Timer;
    public float Sekunder;
    public float Minuter;

    public float RandomR;
    public float RandomG;
    public float RandomB;
    
    public float x;
    public float y;
    public float z;

    [Range(-720, 720)]
    public float rotationSpeed;

    // Use this for initialization
    void Start()
    {
        x = Random.Range(-9.4f, 9.4f);
        y = Random.Range(-5.55f, 5.55f);
        z = 0;
        //Dom olika värderna för möjliga positioner för Ship.
        transform.position = new Vector3(x, y, z);
        //Nu när jag startar ska Ship spwna på en random position innom värderna i new Vector3.

        speed = Random.Range(4f, 15f);
        //Speed är nu en random hastighet.
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
        //Nu håller Ship den random speed som slumpades vid start.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomR = Random.Range(0f, 1f);
            //Random röd färg.
            RandomG = Random.Range(0f, 1f);
            //Random grön färg.
            RandomB = Random.Range(0f, 1f);
            //Random blå färg.
            rend.color = new Color(RandomR, RandomG, RandomB, 1f);
            //Applicera random färg av röd, grön och blå.
        }

        if (Input.GetKey(KeyCode.A))
        //Detta är så att allt innom måsvingarna efter if:en kommer att ske när man trycker på A.
        {
            transform.Rotate(0f, 0f, rotationSpeed / 2 * Time.deltaTime);
            //Den kommer svänga vänster (långsammare än höger) i den hastighet som är inställd i Unity.
            rend.color = ColorA;
            //När man trycker på A så kommer Ship bli blå.
        }


        if (Input.GetKey(KeyCode.D))
        //Detta är så att allt innom måsvingarna efter if:en kommer att ske när man trycker på D.
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
            //Den kommer svänga höger i den hastighet som är inställd i Unity.
            rend.color = ColorD;
            //Nu när man trycker på D så kommer även Ship bli blå som är den färgen jag har ställt in ColorD på i Unity.
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            speed = speed / 2;
            //Nu ska Ships hastighet saktas ner när man trycker på S.
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            speed = speed * 2;
            //Det här ska se till att hastigheten går tillbaka till sin vanliga hastighet när vi släpper S eftersom att en annan typ av kod inte fungerade.
        }

        Timer += Time.deltaTime;
        //Detta gär så att timern går i sekunder och inte per frame.
        Sekunder = Timer % 60;
        //Så att den byter när det gått 60 sekunder.
        Minuter = (Timer / 60);
        //Timern i minuter.
        print(string.Format("{0:0}:{01:00}", Minuter, Sekunder));
        //Den snygga timer printaren i rätt ordning.

        if (transform.position.x < -9.4)
        {
            transform.position = new Vector3(9.4f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 9.4)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -5.55)
        {
            transform.position = new Vector3(transform.position.x, -5.55f, transform.position.z);
        }
        if (transform.position.y > 5.55)
        {
            transform.position = new Vector3(transform.position.x, 5.55f, transform.position.z);
        }
        //Om Ship går utanför skärmen så spwanar Ship i bestämd position

    }
}
