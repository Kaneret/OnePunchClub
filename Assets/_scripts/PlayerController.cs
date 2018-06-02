using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector2 target;

    private bool isFacingRight = true;
    public Animator _animatorController;

    public Training ObjTrain;

    //float reloadTimer = 2.0f;

    void Start()
    {
        target = transform.position;
        _animatorController = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = transform.position.y;
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            if (direction.x > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && isFacingRight)
            {
                Flip();
            }

        }
        //if ((target.x > -11) && (target.x < 10))
        //{
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //}

        if (target.x == transform.position.x)
        {
            _animatorController.Play("Staying");
        }
        else
        {
            _animatorController.Play("Walking");
        }
    }

    private void Flip()
    {
        //меняем направление движения персонажа 
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа 
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х 
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный 
        transform.localScale = theScale;
    }

  


}


