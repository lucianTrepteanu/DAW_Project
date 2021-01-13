using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Shop.Application.Data
{
    public interface IUpload
    {
        CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
    }
}
