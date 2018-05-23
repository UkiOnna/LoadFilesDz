using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace UploadFileDz
{
    public class LoadFile
    {
        public LoadFile()
        {
            var task = Task.Run(Go);
        }

        public async Task Go()
        {
            using (var dbx = new DropboxClient("1OHT5jM4DZYAAAAAAAAACjP94bicuOdxRJ41CBev9E5vK2B8nCX04bw4TJZyEnnN"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine($"Name - {full.Name.DisplayName} Email - {full.Email}");
                byte[] content = File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\HelloUki.txt");
                var memory = new MemoryStream(content);
                var updated = await dbx.Files.UploadAsync(
                   "" + "/" + "PrIVEEEEETE.txt",
                   WriteMode.Overwrite.Instance, body: memory);

                Console.WriteLine($"Saved   /Privki.txt rev {updated.Rev}");
            }
        }

    }
}
