using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

// setx AZURE_STORAGE_CONNECTION_STRING "connectionString"

var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

// Use the following .NET classes to interact with these resources:
//     - BlobServiceClient: The BlobServiceClient class allows you to manipulate Azure Storage resources and blob containers.
//     - BlobContainerClient: The BlobContainerClient class allows you to manipulate Azure Storage containers and their blobs.
//     - BlobClient: The BlobClient class allows you to manipulate Azure Storage blobs.

// 1. Create a container
var blobServiceClient = new BlobServiceClient(connectionString);

var containerName = "myfirstblob";

BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

// 2. Upload blob co a container
var localPath = "data";
Directory.CreateDirectory(localPath);
var fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
var localFilePath = Path.Combine(localPath, fileName);

await File.WriteAllTextAsync(localFilePath, "Hello, World!");

BlobClient blobClient = containerClient.GetBlobClient(fileName);

Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

await blobClient.UploadAsync(localFilePath, true);

// 3. List blobs in a container
Console.WriteLine("Listing blobs...");

await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
{
    Console.WriteLine("\t" + blobItem.Name);
}

// 4. Download a blob
var downloadFilePath = localFilePath.Replace(".txt", "DOWNLOADED.txt");
Console.WriteLine($"\nDownloading blob to\n\t{downloadFilePath}\n");

await blobClient.DownloadToAsync(downloadFilePath);

// 5. Delete a container
Console.Write("Press any key to being clean up");
Console.ReadLine();

Console.WriteLine("Deleting blob container...");
await containerClient.DeleteAsync();

Console.WriteLine("Deleting the local source and downloaded files...");
File.Delete(localFilePath);
File.Delete(downloadFilePath);

Console.WriteLine("Done.");