

class Program
{
    static async Task Main(string[] args)
    {
        string token = "7445485820:AAFOk0Laq-b9JuxJFCaIYe2w0NLyvNcsY0E";

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