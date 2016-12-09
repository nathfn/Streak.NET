using System;
using Streak.Net.Api.Models;

namespace Streak.Net.Api.Services.Raw
{
    public class RawFileServices: RawServicesBase
    {
        internal RawFileServices(string apiKey, string apiBaseUrl) : base(apiKey, apiBaseUrl){ }

        /// <summary>
        /// This call lets you get all the files associated with a particular box.
        /// </summary>
        /// <param name="boxKey">The key of the box for which you want the files listed</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a box key!</exception>
        public RawApiResponse ListFiles(string boxKey)
        {
            if (string.IsNullOrEmpty(boxKey))
                throw new ArgumentNullException(nameof(boxKey), "Please specify a box key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.ListFiles.Replace("{boxKey}", boxKey),
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you get a specific file.
        /// </summary>
        /// <param name="fileKey">The key of the file.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a file key!</exception>
        public RawApiResponse GetFile(string fileKey)
        {
            if (string.IsNullOrEmpty(fileKey))
                throw new ArgumentNullException(nameof(fileKey), "Please specify a file key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.GetFile.Replace("{fileKey}", fileKey),
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }

        /// <summary>
        /// This call lets you get a short lived, one time use URL to the file. This link expires quickly and can only be used once.
        /// </summary>
        /// <param name="fileKey">The key of the file.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Please specify a file key!</exception>
        public RawApiResponse GetFileLink(string fileKey)
        {
            if (string.IsNullOrEmpty(fileKey))
                throw new ArgumentNullException(nameof(fileKey), "Please specify a file key!");
            int httpStatusCode;
            var json = Http.Get(ApiHandles.GetFileLink.Replace("{fileKey}", fileKey),
                out httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
