using System;
using System.Net.Http;
using System.Threading;
using ServiceStack.Redis;

public class Program
{
    private static HttpClient Client = new HttpClient();
    private const string rng_uri = "http://rng";
    private const string hasher_uri = "http://hasher";
    private static IRedisClient redis;

    public static void Main(){
        Console.WriteLine("Worker starting...");
        var manager = new RedisManagerPool("redis:6379");
        redis = manager.GetClient();
        while (true){
            try{
                WorkLoop();
            } catch(Exception ex) {
                Console.WriteLine("Exception: In work loop: {0}", ex);
                Console.WriteLine("Error: Waiting 10s and restarting");
                Thread.Sleep(10000);    // 10 sec
            }
        }
    }

    private static void WorkLoop(int interval = 1){
        double deadline = 0;
        var loopsDone = 0;
        while (true){
            if (GetTimeInSeconds() > deadline){
                Console.WriteLine("{0} unit of work done, updating hash counter", loopsDone);
                redis.IncrementValueBy("hashes", loopsDone);
                loopsDone = 0;
                deadline =GetTimeInSeconds() + interval;
            }
            WorkOnce();
            loopsDone += 1;
        }
    }

    private static double GetTimeInSeconds()
    {
        return (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
    }

    private static void WorkOnce(){
        Console.WriteLine("Doing one unit of work");
        Thread.Sleep(100);  // 100 ms
        var randomBytes = GetRandomBytes();
        var hexHash = HashBytes(randomBytes);
        if(!hexHash.StartsWith("0")){
            Console.WriteLine("No coin found");
            return;
        }
        Console.WriteLine("Count found: {0}...", hexHash);
        var created = redis.SetEntryInHash("wallet", hexHash, Convert.ToBase64String(randomBytes));
        if(!created){
            Console.WriteLine("We already had that coin");
        }
    }

    private static byte[] GetRandomBytes(){
        var result = Client.GetAsync($"{rng_uri}/32").Result;
        return result.Content.ReadAsByteArrayAsync().Result;
    }

    private static string HashBytes(byte[] bytes){
        var value = Convert.ToBase64String(bytes);
        var uri = $"{hasher_uri}/{value}";
        var result = Client.PostAsync(uri, null).Result;
        return result.Content.ReadAsStringAsync().Result;
    }
}
