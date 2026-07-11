namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // Send GET request
        var response = await client.GetAsync(
            "https://themealdb.com/api/json/v1/1/search.php?f=a");

        // Check status code
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code should be 200 OK.");

        // Read response body
        var body = await response.Content.ReadAsStringAsync();

        // Parse JSON
        using var document = System.Text.Json.JsonDocument.Parse(body);

        // Get meals array
        var meals = document.RootElement.GetProperty("meals");

        if (meals.ValueKind == System.Text.Json.JsonValueKind.Null)
            throw new Exception("Meals should not be null.");

        if (meals.GetArrayLength() == 0)
            throw new Exception("Meals array should contain at least one item.");

        // Print each meal name
        foreach (var meal in meals.EnumerateArray())
        {
            var mealName = meal.GetProperty("strMeal").GetString();
            Console.WriteLine(mealName);
        }
    }
}