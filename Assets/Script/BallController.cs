using UnityEngine;
public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 2).normalized;
        rigid.AddForce(arah * force);
    }
    // Update is called once per frame
    void Update()
    {   
    }
    private void OnCollisionEnter2D (Collision2D coll)
    {
        if(coll.gameObject.name == "tepiAtas"){
            RessetBall();
            Vector2 arah = new Vector2 (0,2).normalized;
            rigid.AddForce (arah * force);
        }
        if(coll.gameObject.name == "tepiBawah"){
            RessetBall();
            Vector2 arah = new Vector2(0, -2).normalized;
            rigid.AddForce(arah * force);
        }
        if (coll.gameObject.name == "pemukul1" || coll.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.x - coll.transform.position.x) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.y, sudut).normalized;
            rigid.velocity = new Vector2(0,0);
            rigid.AddForce(arah * force *2);
        }
    }
        void RessetBall()
        {
            transform.localPosition = new Vector2 (0,0);
            rigid.velocity = new Vector2 (0,0);
        }
}
