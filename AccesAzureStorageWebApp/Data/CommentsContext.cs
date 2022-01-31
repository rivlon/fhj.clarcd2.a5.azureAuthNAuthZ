﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccesAzureStorageWebApp.Helpers;
using AccesAzureStorageWebApp.Models;
using Microsoft.Extensions.Options;

namespace AccesAzureStorageWebApp.Data
{
    public class CommentsContext
    {
        // make sure that appsettings.json is filled with the necessary details of the azure storage
        private readonly AzureStorageConfig _config = null;

        public CommentsContext(IOptions<AzureStorageConfig> config)
        {
            _config = config.Value;

        }

        public List<Comment> Comments { get; set; }

        public async Task<List<Comment>> GetComments()
        {
            List<CommentBlobDTO> blobs = await StorageHelper.GetBlobs(_config.AccountName, _config.ContainerName);

            List<Comment> comments = new List<Comment>();
            foreach (CommentBlobDTO blob in blobs)
            {
                Comment comment = new Comment();
                comment.Name = blob.Name;
                comment.UserComment = blob.Contents;

                comments.Add(comment);
            }

            return comments;
        }

        public async Task CreateComment(Comment comment)
        {
            await StorageHelper.UploadBlob(_config.AccountName, _config.ContainerName, comment.Name, comment.UserComment);
        }

        public async Task DeleteComment(Comment comment)
        {

            await StorageHelper.DeleteBlob(_config.AccountName, _config.ContainerName, comment.Name);
        }
    }
}
