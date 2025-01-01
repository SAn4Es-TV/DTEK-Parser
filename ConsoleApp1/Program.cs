using Newtonsoft.Json.Linq;

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Xml.Linq;

public class Program {
    public static async Task Main() {
        string group = "group_3";           //dsadsadsa
        string range = "";
        HttpClient client = new HttpClient();
        string page = await client.GetStringAsync("https://api.yasno.com.ua/api/v1/pages/home/schedule-turn-off-electricity");
        JObject json = JObject.Parse(page);
        JToken jToken = json["components"][4]["dailySchedule"]["dnipro"]["today"]["groups"]["3"];

        range += jToken[0]["start"] + "-";
        for (int i = 0; i < jToken.ToList().Count; i++) {
            try {
                Debug.Write(jToken[i]["start"] + "-" + jToken[i]["end"] + "  ==  ");
                if (jToken[i + 1]["start"].ToString() != jToken[i]["end"].ToString()) {
                    Debug.WriteLine(jToken[i]["start"] + "-" + jToken[i]["end"]);
                    //Debug.WriteLine(jToken[i]["start"] + "-" + jToken[i]["end"]);
                    range += jToken[i]["end"]; 
                    range += " | " + jToken[i+1]["start"] + "-";
                }
            }catch(Exception e) {
                range += jToken[i]["end"];
            }
        }
        Console.WriteLine(range);

    }
}