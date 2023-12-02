using Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;

namespace TestProject;

public class TaskControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TaskControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetTasks_ShouldReturnTasks()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/tasks");
        var content = await response.Content.ReadAsStringAsync();
        var tasks = JsonConvert.DeserializeObject<TaskModel[]>(content);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(tasks);
        Assert.Empty(tasks); // Assuming initially, there are no tasks
    }

    [Fact]
    public async Task CreateTask_ShouldCreateTask()
    {
        // Arrange
        var client = _factory.CreateClient();
        var newTask = new TaskModel { Title = "Test Task", Description = "This is a test task." };
        var serializedTask = JsonConvert.SerializeObject(newTask);

        // Act
        var response = await client.PostAsync("/api/tasks", new StringContent(serializedTask, System.Text.Encoding.UTF8, "application/json"));

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}