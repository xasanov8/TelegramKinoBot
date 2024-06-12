

class Program
{
    static async Task Main(string[] args)
    {
        string token = "6870782628:AAEH_4ldeBRsAiqg67mcGgEoNNH63iDdppw";

        BotHandler handle = new BotHandler(token);

        try
        {
            await handle.BotHandle();
        }
        catch
        {
            await handle.BotHandle();
        }
    }
}