using SqsOperations;

Console.WriteLine("Nayeem Rahman - AWS SQS Operations");

var queueOperation = new QueueOperation();
var url = "https://sqs.us-east-1.amazonaws.com/847888492411/nayeem_queue";

#region Create Queue

var create = await queueOperation.CreateQueueAsync("nayeem_queue");
Console.WriteLine(create);

#endregion

#region Add Message

var numberOfMessages = 10;
var body = new string[numberOfMessages];
var messageId = new string[numberOfMessages];
for (var i = 0; i < numberOfMessages; i++)
{
    var counter = 1;
    body[i] = $"Sample message {counter}";
    messageId[i] = await queueOperation.AddMessage(url, body[i]);
    Console.WriteLine(messageId[i]);
    counter++;
}

#endregion

#region Read Message

var result = await queueOperation.ReadMessages(url, 10);

foreach (var message in result)
{
    Console.WriteLine($"Id: {message.MessageId}, Message Body: {message.Body}");
}

#endregion

#region Delete Message

await queueOperation.DeleteReadMessage(url, 10);

#endregion