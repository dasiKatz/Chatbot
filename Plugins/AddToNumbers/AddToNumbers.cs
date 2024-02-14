using BasePlugin;
using BasePlugin.Interfaces;
using BasePlugin.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AddToNumbers
{ 

    record PersistentDataStructure(int result);
    public class AddToNumbersPlugin : IPlugin
    {
        public static string _Id = "AddToNumbers";
        public string Id => Id;
 
        public PluginOutput Execute(PluginInput input)
        {
            Random random = new Random();

          
            if (input.Message == "")
            {
                input.Callbacks.StartSession();

                int num1 = random.Next(1, 21);
                int num2 = random.Next(1, 21-num1);

                int result = num1 + num2;
                var data = new PersistentDataStructure(result);
                return new PluginOutput($"{num1}+{num2}=", JsonSerializer.Serialize(data));
            }
        
            else if (int.TryParse(input.Message, out int useResult))
            {
                int result = JsonSerializer.Deserialize<PersistentDataStructure>(input.PersistentData).result;

                if (useResult != result)
                {
                    return new PluginOutput($"The result is error. Enter correct result.",JsonSerializer.Serialize(new PersistentDataStructure(result)));
                }
                else
                {
           
                    return new PluginOutput("yessssss!!!!");
                }
            }
            else
                return new PluginOutput("Enter something legal");





        }
    }
}

