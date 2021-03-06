using System;
using Newtonsoft.Json.Serialization;

namespace ProjectStarter {

    public interface IConfig {
        string RawConfig { get; set; }
        string RootDirectory { get; set; }
        string LibPath { get; }
        string[] SubDirectories { get; set; }
        Package[] Packages { get; }
    }

    public class Config : IConfig{

        public string RawConfig { get; set; }
        public string RootDirectory { get; set; }
        public string[] SubDirectories { get; set; }

        public static IConfig LoadConfig(string configFileContents) {
            if(String.IsNullOrEmpty(configFileContents))
                throw new ArgumentException("The file contents must contain valid JSON");
            var config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(configFileContents);
            config.RawConfig = configFileContents;
            return config;

        }


        public string LibPath { get; set; }

        public Package[] Packages { get; set; }
    }    

}

