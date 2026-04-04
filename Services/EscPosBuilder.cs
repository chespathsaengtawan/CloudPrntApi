
using System.Text;

namespace CloudPrntApi.Services;

public static class EscPosBuilder
{
    public static byte[] BuildTestReceipt()
    {
        var list = new List<byte>();

        void Add(params byte[] b) => list.AddRange(b);
        void Text(string s) => Add(Encoding.UTF8.GetBytes(s));

        Add(0x1B, 0x40);           // Initialize
        Add(0x1B, 0x61, 0x01);     // Center
        Text("CloudPRNT HTTP OK\n");
        Add(0x1B, 0x61, 0x00);     // Left

        Text("TSP100IV / TSP143IV\n");
        Text(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        Text("\n\n");

        Add(0x1D, 0x56, 0x01);     // Cut

        return list.ToArray();
    }
}
