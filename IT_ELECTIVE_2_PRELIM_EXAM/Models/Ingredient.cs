namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

public class Ingredient
{
    private string name;
    private string measure;
    private double quantity;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            name = value;
        }
    }

    public string Measure
    {
        get => measure;
        set => measure = value;
    }

    public double Quantity
    {
        get => quantity;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Quantity));
            }

            quantity = value;
        }
    }

    public Ingredient()
    {
        Name = "";
        Measure = "";
        Quantity = 0;
    }

    public Ingredient(string name, string measure, double quantity)
    {
        Name = name;
        Measure = measure;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Quantity} {Measure} of {Name}";
    }
}
