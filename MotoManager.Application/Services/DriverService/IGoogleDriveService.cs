namespace MotoManager.Application.Services.DriverService
{
    /// <summary>
    /// Interface para manipulação de arquivos no Google Drive.
    /// </summary>
    public interface IGoogleDriveService
    {
        /// <summary>
        /// Faz o upload de uma imagem para o Google Drive.
        /// </summary>
        /// <param name="base64Image">Imagem em formato Base64.</param>
        /// <param name="fileName">Nome do arquivo no Google Drive.</param>
        /// <param name="folderId">ID da pasta onde o arquivo será armazenado.</param>
        /// <returns>O ID do arquivo salvo no Google Drive.</returns>
        Task<string> UploadBase64ImageAsync(string base64Image, string fileName, string folderId = "1CXy6OINGS0ue-4CYeXOcqVZLMBbBxHKC");
    }
}
