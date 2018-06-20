
public class Characteristic
{
    public Characteristic(int Value)
    {
        this.Value = Value;
        Bar = new Parameter(100, 0);
    }

    public int Value { get; set; }

    /// <summary>
    /// шкала развития характеристик
    /// </summary>
    public Parameter Bar;
}
