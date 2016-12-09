using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Streak.Net.Api.Models;
using Streak.Net.Api.Services.Raw;

namespace Streak.Net.Api.Services
{
    public class FileServices: ServicesBase
    {
        private readonly RawFileServices _rawFileServices;

        internal FileServices(string apiKey, string apiBaseUrl, bool includeRawResponse) : base(includeRawResponse)
        {
            _rawFileServices = new RawFileServices(apiKey, apiBaseUrl);
        }

        /// <summary>
        /// This call lets you get all the files associated with a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box for which you want the files listed</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a box key!</exception>
        public FileList ListFiles(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            var fileList = new FileList
            {
                RawApiResponse = _rawFileServices.ListFiles(boxKey)
            };
            fileList.Files = JsonConvert.DeserializeObject<List<File>>(fileList.RawApiResponse.Json);
            fileList.RawApiResponse = GetRawApiResponseOrNull(fileList.RawApiResponse);
            return fileList;
        }

        /// <summary>
        /// This call lets you get a specific file.
        /// </summary>
        /// <param name="fileKey">The key of the file.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a file key!</exception>
        public File GetFile(string fileKey)
        {
            if (string.IsNullOrEmpty(fileKey))
                throw new ArgumentNullException(nameof(fileKey), "Please specify a file key!");
            var rawResponse = _rawFileServices.GetFile(fileKey);
            var file = JsonConvert.DeserializeObject<File>(rawResponse.Json);
            file.RawApiResponse = GetRawApiResponseOrNull(rawResponse);
            return file;

        }

        /// <summary>
        /// This call lets you get a short lived, one time use URL to the file. This link expires quickly and can only be used once.
        /// </summary>
        /// <param name="fileKey">The key of the file.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a file key!</exception>
        public string GetFileLink(string fileKey)
        {
            if (string.IsNullOrEmpty(fileKey))
                throw new ArgumentNullException(nameof(fileKey), "Please specify a file key!");
            var rawResponse = _rawFileServices.GetFile(fileKey);
            return JsonConvert.DeserializeObject<string>(rawResponse.Json);
        }
    }
}
