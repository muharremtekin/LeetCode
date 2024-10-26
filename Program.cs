
List<string> logs = ["88 99 200", "88 99 300", "99 32 100", "12 12 15"];
int threshold = 2;

var res = OnlineAssesmentDemoQuestionOne.ProcessLogs(logs, threshold);

Console.WriteLine(res);