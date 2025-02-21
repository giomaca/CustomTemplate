namespace CustomTemplate.API.Endpoints;

public static class Endpoints
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.MapGet("Test/One", (string PersonalN) => "Test");
    }
}
