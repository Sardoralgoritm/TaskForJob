namespace Library.Tests.BusinessLogic;

[TestFixture]
public class BookServiceTests
{
    private Mock<IBookInterface> _mockBookInterface;
    private BookService _bookService;

    [SetUp]
    public void SetUp()
    {
        _mockBookInterface = new Mock<IBookInterface>();
        _bookService = new BookService(_mockBookInterface.Object);
    }

    [Test]
    public async Task CreateBookAsync_ValidInput_ShouldCreateBook()
    {
        // Arrange
        var addBook = new AddBookDTO { Title = "Test Title", Author = "Test Author", CategoryName = "Test Category" };

        // Act
        await _bookService.CreateBookAsync(addBook);

        // Assert
        _mockBookInterface.Verify(x => x.Create(It.IsAny<Book>()), Times.Once);
    }

    [Test]
    public void CreateBookAsync_NullInput_ShouldThrowException()
    {
        // Arrange
        AddBookDTO addBook = null;

        // Act & Assert
        Assert.ThrowsAsync<CustomException>(() => _bookService.CreateBookAsync(addBook));
    }

    [Test]
    public async Task DeleteBookAsync_ExistingId_ShouldDeleteBook()
    {
        // Arrange
        string id = "1";
        var book = new Book { Id = id };

        _mockBookInterface.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(book);

        // Act
        await _bookService.DeleteBookAsync(id);

        // Assert
        _mockBookInterface.Verify(x => x.DeleteByIdAsync(id), Times.Once);
    }

    [Test]
    public void DeleteBookAsync_NonExistingId_ShouldThrowException()
    {
        // Arrange
        string id = "1";

        _mockBookInterface.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Book)null);

        // Act & Assert
        Assert.ThrowsAsync<CustomException>(() => _bookService.DeleteBookAsync(id));
    }

    [Test]
    public async Task GetBookById_ExistingId_ShouldReturnBookDTO()
    {
        // Arrange
        string id = "1";
        var book = new Book { Id = id, Title = "Test Title", Author = "Test Author", CategoryName = "Test Category" };
        var expectedBookDTO = new BookDTO { Id = id, Title = "Test Title", Author = "Test Author", CategoryName = "Test Category" };

        _mockBookInterface.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(book);

        // Act
        var result = await _bookService.GetBookById(id);

        // Assert
        Assert.AreEqual(expectedBookDTO.Id, result.Id);
        Assert.AreEqual(expectedBookDTO.Title, result.Title);
        Assert.AreEqual(expectedBookDTO.Author, result.Author);
        Assert.AreEqual(expectedBookDTO.CategoryName, result.CategoryName);
    }

    [Test]
    public void GetBookById_NonExistingId_ShouldThrowException()
    {
        // Arrange
        string id = "1";

        _mockBookInterface.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Book)null);

        // Act & Assert
        Assert.ThrowsAsync<CustomException>(() => _bookService.GetBookById(id));
    }

    [Test]
    public async Task UpdateBookAsync_ExistingId_ShouldUpdateBook()
    {
        // Arrange
        string id = "1";
        var updateBook = new UpdateBookDTO { Id = id, Title = "Updated Title", Author = "Updated Author", CategoryName = "Updated Category" };
        var existingBook = new Book { Id = id, Title = "Original Title", Author = "Original Author", CategoryName = "Original Category" };

        _mockBookInterface.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(existingBook);

        // Act
        await _bookService.UpdateBookAsync(updateBook);

        // Assert
        _mockBookInterface.Verify(x => x.Update(It.IsAny<Book>()), Times.Once);
    }

    [Test]
    public void UpdateBookAsync_NonExistingId_ShouldThrowException()
    {
        // Arrange
        string id = "1";
        var updateBook = new UpdateBookDTO { Id = id, Title = "Updated Title", Author = "Updated Author", CategoryName = "Updated Category" };

        _mockBookInterface.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Book)null);

        // Act & Assert
        Assert.ThrowsAsync<CustomException>(() => _bookService.UpdateBookAsync(updateBook));
    }
}