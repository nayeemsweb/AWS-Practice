using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace DynamoDbOperation
{
    public class DynamoDbOperations
    {
        private static AmazonDynamoDBClient _client;
        private DynamoDBContext _context;
        public DynamoDbOperations()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_client);
        }

        #region AddBook
        public async Task AddBook(Book book)
        {
            // Save the book.
            await _context.SaveAsync(book);
        }

        #endregion

        #region GetBook
        public async Task GetBook(int id)
        {
            var result = await _context.LoadAsync<Book>(id);
            Console.WriteLine($"ID:\t{result.Id}");
            Console.WriteLine($"Title:\t{result.Title}\n");
        }

        #endregion

        #region DeleteBook
        public async Task DeleteBook(int id)
        {
            if (await _context.LoadAsync<Book>(id) != null)
            {
                await _context.DeleteAsync<Book>(id);
                Console.WriteLine("Deleted!!!");
            }
            else
            {
                Console.WriteLine("Could not delete!!!");
            }
        }

        #endregion
    }
}