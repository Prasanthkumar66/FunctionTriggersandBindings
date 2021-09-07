using System;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, 
            [Blob("dev/{name}",FileAccess.Write,Connection = "AzureWebJobsStorage")] Stream blob,string name,  ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes \n ");
            StreamReader reader = new StreamReader(myBlob);
            blob.Write(Encoding.ASCII.GetBytes(reader.ReadToEnd()));           
            
        }
    }
}
