public sealed class TaskTest
{
    public async Task<string> GetValueAsyncTask()
    {
        Console.WriteLine("async Task<string> GetValueAsyncTask() BAŞLADI ");
        int sonuc = 1;
        for (int i = 1; i < 999999999; i++)
        {
            sonuc *= i;
        }
        await Task.Delay(3000);
        Console.WriteLine("public async Task<string> GetValueAsyncTask() BİTTİ");
        return sonuc.ToString();
    }
    public Task<string> GetValueTask()
    {
        Console.WriteLine("Task<string> GetValueTask() BAŞLADI");
        int sonuc = 1;
        for (int i = 1; i < 999999999; i++)
        {
            sonuc *= i;
        }
        Console.WriteLine("public Task<string> GetValueTask() BİTTİ");
        return Task.FromResult(sonuc.ToString());
    }
    public string GetValue()
    {
        Console.WriteLine("public string GetValue() BAŞLADI");
        int sonuc = 1;
        for (int i = 1; i < 999999999; i++)
        {
            sonuc *= i;
        }
        Console.WriteLine("public string GetValue()");
        return sonuc.ToString();
    }
}