using System;
using ProjectStarter;
using ProjectStarter_Tests.Mocks;
using Xunit;

namespace ProjectStarter_Tests.UnitTests {

    public class when_using_a_json_config_file {

        private MockFileSystem _mockFileSystem;
        private ArgParser _parser;

        private const string DefaultConfigFileName = "default.json";
        private const string JsonConfig =  @"{ ""RootDirectory"": ""Test"" }";
            

        public when_using_a_json_config_file() {
            _mockFileSystem = new MockFileSystem();
            _mockFileSystem.ReturnFromReadFile = JsonConfig;
            _parser = new ArgParser(null, _mockFileSystem);
        }

        [Fact]
        public void should_read_the_default_config() {
            Assert.Contains(DefaultConfigFileName ,_mockFileSystem.FilesRead );
        }

        [Fact]
        public void should_deserialize_the_config_file() {
            Assert.NotNull(_parser.Config);
        }

        [Fact]
        public void Config_property_should_contain_the_config_contents() {
            Assert.Equals(JsonConfig, _parser.Config.Config);
        }

        [Fact]
        public void config_file_should_be_the_proper_type() {
            Assert.IsType(typeof(ProjectStarterConfig), _parser.Config);
        }

        [Fact]
        public void config_object_should_contain_a_project_root_name() {
            Assert.NotNull(_parser.Config.RootDirectory);
            Assert.IsType(typeof(string), _parser.Config.RootDirectory);
        }
    }
}