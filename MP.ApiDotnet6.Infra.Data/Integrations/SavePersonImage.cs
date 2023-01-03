using MP.ApiDotNet6.Domain.Integrations;

namespace MP.ApiDotnet6.Infra.Data.Integrations
{
    public class SavePersonImage : ISavePersonImage
    {
        private readonly string _filepath;

        public SavePersonImage()
        {
            _filepath = "C:\\Users\\adoni\\OneDrive\\Imagens\\ImagensProjeto";
        }

        public string Save(string imageBase64)
        {
            var fileExtension = imageBase64.Substring(imageBase64.IndexOf("/") + 1, 
                                imageBase64.IndexOf(";") - imageBase64.IndexOf("/")-1);

            var base64Code = imageBase64.Substring(imageBase64.IndexOf(",") + 1 );
            var imgByte = Convert.FromBase64String(base64Code);

            var filename = Guid.NewGuid().ToString() + "." + fileExtension;

            using(var imageFile = new FileStream(_filepath+"/"+filename, FileMode.Create))
            {
                imageFile.Write(imgByte);
                imageFile.Flush();
            }

            return _filepath + "\\" + filename;
        }
    }
}
