namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var response = await client.GetAsync(
            "https://themealdb.com/api/json/v1/1/lookup.php?i=999999");

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code should be 200 OK.");

        var body = await response.Content.ReadAsStringAsync();

        using var document = System.Text.Json.JsonDocument.Parse(body);

        var meals = document.RootElement.GetProperty("meals");

        if (meals.ValueKind != System.Text.Json.JsonValueKind.Null)
            throw new Exception("Meals should be null for a non-existent meal.");
    }
}