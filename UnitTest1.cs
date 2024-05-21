namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            using var context = DbContextFactory.Create();
            var service = new UserService(context);

            // Act
            var users = service.GetAllUsers();

            // Assert
            Assert.Equal(100, users.Count());
        }
    }
}