namespace Library.Tests.Data;

[TestFixture]
public class RepositoryTests
{
    private DbContextOptions<AppDbContext> options;
    private AppDbContext appDbContext;

    [SetUp]
    public void SetUp()
    {
        options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "libraryDB")
            .Options;

        appDbContext = new AppDbContext(options);
    }

    [TearDown]
    public void TearDown()
    {
        appDbContext.Database.EnsureDeleted();
        appDbContext.Dispose();
    }

    [Test]
    public async Task Create_Should_Add_Entity()
    {
        var repository = new Repository<Book>(appDbContext);

        var entity = new Book { Id = "1", Title = "Test Book", CategoryName = "Test Category", Author = "Test Author" };

        await repository.Create(entity);

        var result = await appDbContext.Books.FirstOrDefaultAsync(e => e.Id == entity.Id);

        Assert.IsNotNull(result);
        Assert.AreEqual("1", result.Id);
    }

    [Test]
    public async Task DeleteByIdAsync_Should_Remove_Entity()
    {
        var repository = new Repository<Book>(appDbContext);

        var entity = new Book { Id = "1", Title = "Test Book", CategoryName = "Test Category", Author = "Test Author" };

        await repository.Create(entity);
        await repository.DeleteByIdAsync("1");

        var result = await appDbContext.Books.FirstOrDefaultAsync(e => e.Id == entity.Id);

        Assert.IsNull(result);
    }

    [Test]
    public async Task GetAllAsync_Should_Return_All_Entities()
    {
        var repository = new Repository<Book>(appDbContext);

        var entity1 = new Book { Id = "1", Title = "Test Book 1", CategoryName = "Test Category 1", Author = "Test Author 1" };
        var entity2 = new Book { Id = "2", Title = "Test Book 2", CategoryName = "Test Category 2", Author = "Test Author 2" };

        await repository.Create(entity1);
        await repository.Create(entity2);

        var result = await repository.GetAllAsync();

        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public async Task GetByIdAsync_Should_Return_Entity()
    {
        var repository = new Repository<Book>(appDbContext);

        var entity = new Book { Id = "1", Title = "Test Book", CategoryName = "Test Category", Author = "Test Author" };

        await repository.Create(entity);

        var result = await repository.GetByIdAsync("1");

        Assert.IsNotNull(result);
        Assert.AreEqual("1", result.Id);
    }

    [Test]
    public async Task Update_Should_Modify_Entity()
    {
        var repository = new Repository<Book>(appDbContext);

        var entity = new Book { Id = "1", Title = "Test Book", CategoryName = "Test Category", Author = "Test Author" };

        await repository.Create(entity);

        entity.Title = "Updated Test Book";
        await repository.Update(entity);

        var result = await appDbContext.Books.FirstOrDefaultAsync(e => e.Id == entity.Id);

        Assert.IsNotNull(result);
        Assert.AreEqual("Updated Test Book", result.Title);
    }
}