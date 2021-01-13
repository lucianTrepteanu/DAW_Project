using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Data
{
    public class UploadService : IUpload
    {
        CloudBlobContainer IUpload.GetBlobContainer(string connectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }
    }
}
