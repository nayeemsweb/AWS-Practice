using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqsOperations
{
    public class QueueOperation
    {
        private readonly AmazonSQSClient _client;
        public QueueOperation()
        {
            _client = new AmazonSQSClient();
        }

        #region CreateQueueAsync
        public async Task<string> CreateQueueAsync(string queueName)
        {
            var request = new CreateQueueRequest(queueName);
            var response = await _client.CreateQueueAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return response.QueueUrl;
            else
                return null;
        }

        #endregion

        #region AddMessage
        public async Task<string> AddMessage(string url, string body)
        {
            var request = new SendMessageRequest(url, body);
            var response = await _client.SendMessageAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return response.MessageId;
            else
                return null;
        }

        #endregion

        #region ReadMessages
        public async Task<IList<Message>> ReadMessages(string url, int numberOfMessages)
        {
            var allMessages = new List<Message>();
            var attributeList = new List<string>();
            attributeList.Add("*");
            var request = new ReceiveMessageRequest
            {
                QueueUrl = url,
                MessageAttributeNames = attributeList,
                MaxNumberOfMessages = numberOfMessages
            };
            var response = await _client.ReceiveMessageAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return response.Messages;
            else
                return null;
        }

        #endregion

        #region MyRegion
        public async Task<DeleteMessageResponse> DeleteReadMessage(string url, int numberOfMessagesToDelete)
        {
            var receiveRequest = new ReceiveMessageRequest
            {
                QueueUrl = url,
                MaxNumberOfMessages = numberOfMessagesToDelete
            };

            var response = await _client.ReceiveMessageAsync(receiveRequest);


            var deleteRequest = new DeleteMessageRequest
            {
                QueueUrl = url,
                ReceiptHandle = response.Messages[0].ReceiptHandle
            };

            var deleteResponse = await _client.DeleteMessageAsync(deleteRequest);

            if (deleteResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                return deleteResponse;
            else
                return null;
        }

        #endregion
    }
}