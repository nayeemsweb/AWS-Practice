using S3BucketOperation;

var bucketOperation = new S3BucketOperations();

#region Upload File

await bucketOperation.UplodFileAsync("nayeem-bucket", "anotherSample.txt",
    @"G:\Web\Devskill_ASP.NET_Batch_6\MyCodes\aspnet-b6\Assignment-7\S3BucketOperation\anotherSample.txt");

#endregion

#region Download File

var directory = AppContext.BaseDirectory.Split(Path.DirectorySeparatorChar);
var slice = new ArraySegment<string>(directory, 0, directory.Length - 4);
var downloadDirectory = Path.Combine(slice.ToArray()) + "\\Downloads\\DownloadedFile.txt";

await bucketOperation.DownloadFileAsync("nayeem-bucket", "anotherSample.txt", downloadDirectory);

#endregion

#region Delete File

await bucketOperation.DeleteFileAsync("nayeem-bucket", "anotherSample.txt");
#endregion