using DynamoDbOperation;

var dbOperation = new DynamoDbOperations();

#region Add Row

var book1 = new Book();
book1.Id = 1;
book1.Title = "Book-21";
book1.ISBN = "222-1234567890";
book1.BookAuthors = new List<string> { "Author-1", "Author-2", "Author-3" };

await dbOperation.AddBook(book1);


#endregion

#region Get Data

for (int i = 1; i < 11; i++)
{
    await dbOperation.GetBook(i);
}

#endregion

#region Delete

await dbOperation.DeleteBook(1001);

#endregion