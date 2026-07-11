namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class DeleteReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // Send DELETE request
        var response = await client.DeleteAsync(
            "https://jsonplaceholder.typicode.com/posts/1");

        // Check status code
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Status code should be 200 OK.");
    }
}