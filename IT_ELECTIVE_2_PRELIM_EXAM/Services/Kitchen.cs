using IT_ELECTIVE_2_PRELIM_EXAM.Models;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Services;

public class Kitchen
{
    // Private fields
    private string kitchenName;
    private string headChef;
    private List<Meal> meals;

    // Public read-only property
    public int MealCount { get; private set; }

    public Kitchen(string name, string chef)
    {
        kitchenName = name;
        headChef = chef;
        meals = new List<Meal>();
        MealCount = 0;
    }

    // Public
    public void AddMeal(Meal meal)
    {
        meals.Add(meal);
        MealCount++;
    }

    // Public
    public List<Meal> GetMeals()
    {
        return new List<Meal>(meals);
    }

    // Public
    public bool RemoveMeal(string mealName)
    {
        var meal = meals.FirstOrDefault(m =>
            m.Name.Equals(mealName, StringComparison.OrdinalIgnoreCase));

        if (meal != null)
        {
            meals.Remove(meal);
            MealCount--;
            return true;
        }

        return false;
    }

    // Public
    public string GetKitchenInfo()
    {
        return $"Kitchen: {kitchenName} | Chef: {headChef} | Meals: {MealCount}";
    }

    // Protected
    protected string PrepareMeal(string mealName)
    {
        return $"Preparing {mealName} in {kitchenName}...";
    }
}