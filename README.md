# csapns
APNS Binary Format Implementation

Sample code

    class Program
    {
        static void Main(string[] args)
        {
            var settings = new GateSettings(new X509Certificate2(@"path\cert.p12", "pwd"), workerPoolSize:1);
            var gate = new ApnsGate(settings, new ApnsResponseParser());
            gate.OnProcessed += OnProcessed;

            var payload = @"{""aps"":{""alert"":{""title"":""Game Request"",""body"":""Bob wants to play poker"",""action-loc-key"":""PLAY""},""badge"":1}}";

            gate.Enqueue(new Push("deviceToken", payload, new Dictionary<string, object>()
            {
                /*custom id*/
                {"ID", Guid.NewGuid()},
            }));

            Console.ReadLine();
            gate.Close();
        }

        private static void OnProcessed(PushResponse response)
        {
            var id = (Guid) response.Instance.Attributes["ID"];

            var sb = new StringBuilder()
                .AppendLine("response")
                .AppendLine("ID: " + id)
                .AppendLine("Token " + response.Instance.Token)
                .AppendLine("CreateDate: " + response.CrateDate)
                .AppendLine("Status: " + response.Status)
                .AppendLine("Body: " + response.Body);

            Console.WriteLine(sb.ToString());
        }
    }