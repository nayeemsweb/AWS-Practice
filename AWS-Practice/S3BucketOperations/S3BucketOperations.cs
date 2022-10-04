using Amazon.S3;
using Amazon.S3.Model;

namespace S3BucketOperation
{
    public class S3BucketOperations
    {
        private readonly AmazonS3Client _client;
        public S3BucketOperations()
        {
            _client = new AmazonS3Client();
        }

        #region UplodFileAsync
        public async Task UplodFileAsync(string bucketName, string fileName, string filePath)
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = fileName,
                FilePath = filePath,
                ContentType = "text/plain"
            };

            putRequest.Metadata.Add("x-amz-meta-title", "someTitle");
            var response2 = await _client.PutObjectAsync(putRequest);
        }

        #endregion

        #region DownloadFileAsync
        public async Task DownloadFileAsync(string bucketName, string fileName, string downloadsFolder)
        {
            try
            {
                var downloadedFileTexts = "";
                var getRequest = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = fileName
                };

                using (var response = await _client.GetObjectAsync(getRequest))
                using (var responseStream = response.ResponseStream)
                using (var streamReader = new StreamReader(responseStream))
                {
                    var contentType = response.Headers["Content-Type"];

                    downloadedFileTexts = streamReader.ReadToEnd();
                    File.WriteAllText(downloadsFolder, downloadedFileTexts);
                    Console.WriteLine("\aFile downloaded to Downloads Folder. Please check the Project Directory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message: {ex.Message}");
            }

        }

        #endregion

        #region DeleteFileAsync
        public async Task DeleteFileAsync(string bucketName, string fileName)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = fileName
            };

            try
            {
                var getResponse = await _client.GetObjectMetadataAsync(
                    new GetObjectMetadataRequest()
                    {
                        BucketName = bucketName,
                        Key = fileName
                    });

                if (getResponse != null)
                {
                    await _client.DeleteObjectAsync(deleteObjectRequest);
                    Console.WriteLine("Deleted!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message: {ex.Message}");
            }
        }

        #endregion
    }
}