namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

using System.Text;
using System.Text.Json;

public static class UpdateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // Create JSON body
        var json = """
        {
            "id": 1,
            "title": "Updated Review",
            "body": "Even better than before!",
            "userId": 1
        }
        """;

        // Create StringContent
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Send PUT request
        var response = await client.PutAsync(
            "https://jsonplaceholder.typicode.com/posts/1",
            content);

        // Check status code
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code should be 200 OK.");

        // Read response
        var body = await response.Content.ReadAsStringAsync();

        // Parse JSON
        using var document = JsonDocument.Parse(body);

        // Verify title
        var title = document.RootElement.GetProperty("title").GetString();

        if (title != "Updated Review")
            throw new Exception("Title should be 'Updated Review'.");
    }
}