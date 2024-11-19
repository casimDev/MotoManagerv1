using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;

namespace MotoManager.Application.Services.DriverService
{

    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly DriveService _driveService;

        public GoogleDriveService()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("/app/client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                                              .CreateScoped(DriveService.ScopeConstants.DriveFile);
            }

            _driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "MotoManager"
            });
        }

        /// <summary>
        /// Uploads a Base64-encoded image to Google Drive.
        /// </summary>
        /// <param name="base64Image">The image content encoded as a Base64 string.</param>
        /// <param name="fileName">The name to be used for the file in Google Drive.</param>
        /// <param name="folderId">The ID of the Google Drive folder where the file will be uploaded.</param>
        /// <returns>The ID of the uploaded file in Google Drive.</returns>
        public async Task<string> UploadBase64ImageAsync(string base64Image, string fileName, string folderId = "1CXy6OINGS0ue-4CYeXOcqVZLMBbBxHKC")
        {
            // Convert the Base64 string back to binary data
            var imageBytes = Convert.FromBase64String(base64Image);

            // Create metadata for the file
            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = fileName,
                Parents = new[] { folderId }
            };

            // Write the image bytes to a memory stream
            using var stream = new MemoryStream(imageBytes);

            // Create a request to upload the file
            var request = _driveService.Files.Create(fileMetadata, stream, "image/jpeg");
            request.Fields = "id";

            // Execute the upload
            var result = await request.UploadAsync();

            // Check for upload errors
            if (result.Status != UploadStatus.Completed)
            {
                throw new Exception($"Failed to upload file: {result.Exception?.Message}");
            }

            // Return the ID of the uploaded file
            return request.ResponseBody.Id;
        }
    }
}
