using System;
using System.IO;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace conversions
{
    public class Xml : IRun
    {
        public string Name => nameof(Xml);

        public async Task RunAsync<T>(T input)
        {
            var serializer = new XmlSerializer(typeof(T)); //создание
            await using var stream = new MemoryStream(); //запись в память
            await using var writer = new StreamWriter(stream, Encoding.UTF8); //кодировка utf8
            serializer.Serialize(writer, input);
            await writer.FlushAsync();
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            var xml = await reader.ReadToEndAsync();
            
            Console.Write($"{xml}\n");
        }
    }
}