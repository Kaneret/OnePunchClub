using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2.0f;
    private Vector2 Target;

    private bool isFacingRight = true;
    public Animator AnimatorController;

    public Training ObjTrain;
    
    void Start()
    {
        Target = transform.position;
        AnimatorController = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Target.y = transform.position.y;
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) 
                                - transform.position;

            if (direction.x > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && isFacingRight)
            {
                Flip();
            }
        }
        transform.position = Vector2.MoveTowards
                                (transform.position, Target, Speed * Time.deltaTime);
        
        if (Target.x == transform.position.x)
        {
            AnimatorController.Play("Staying");
        }
        else
        {
            AnimatorController.Play("Walking");
        }
    }

    private void Flip()
    {         
        isFacingRight = !isFacingRight;      ///меняем направление движения персонажа;        
        Vector3 theScale = transform.localScale;        ///получаем размеры персонажа;
        theScale.x *= -1;                    ///зеркально отражаем персонажа по оси Х;
                                             
        ///задаем новый размер персонажа, 
        ///равный старому, но зеркально отраженный
        transform.localScale = theScale;      
        
    }

  


}


