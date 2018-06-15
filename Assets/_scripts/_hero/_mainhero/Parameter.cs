

public class Parameter
{
    public Parameter(int kol)
    {
        Maximum = kol;
        Quanity = kol;
    }

    public Parameter(int max, int quan)
    {
        Maximum = max;
        Quanity = quan;
    }

    public int Maximum { get; set; }
    public int Quanity { get; set; }

    public void RestoreQuanity(int wane)
    {
        if (Quanity < Maximum)
        {
            Quanity += wane;
        }
        if (Quanity > Maximum)
        {
            Quanity = Maximum;
        }
    }

    public void RestoreQuanity(double percent)
    {
        if (Quanity < Maximum)
        {
            Quanity += (int)(Maximum * percent);
        }
        if (Quanity > Maximum)
        {
            Quanity = Maximum;
        }
    }

    public void DecreaseQuanity(int wane)
    {
        if (Quanity > 0)
        {
            Quanity -= wane;
        }
        if (Quanity < 0)
        {
            Quanity = 0;
        }
    }

    public void DecreaseQuanity(double percent)
    {
        if (Quanity > 0)
        {
            Quanity -= (int)(Maximum * percent);
        }
        if (Quanity < 0)
        {
            Quanity = 0;
        }
    }
    
    public void SetQuanityMaximum()
    {
        Quanity = Maximum;
    }
}
