namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetCategories
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/categories.php");

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code should be 200 OK.");

        var body = await response.Content.ReadAsStringAsync();

        using var document = System.Text.Json.JsonDocument.Parse(body);

        var categories = document.RootElement.GetProperty("categories");

        if (categories.ValueKind == System.Text.Json.JsonValueKind.Null)
            throw new Exception("Categories should not be null.");

        if (categories.GetArrayLength() == 0)
            throw new Exception("Categories array should contain at least one item.");
    }
}